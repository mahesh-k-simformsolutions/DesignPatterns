using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using Throttling.Atrribute;
using Throttling.Extensions;

namespace Throttling.Middlewares;

public class RateLimitingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IDistributedCache _cache;

    public RateLimitingMiddleware(RequestDelegate next, IDistributedCache cache)
    {
        _next = next;
        _cache = cache;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Endpoint? endpoint = context.GetEndpoint();
        LimitRequests? rateLimitingDecorator = endpoint?.Metadata.GetMetadata<LimitRequests>();

        if (rateLimitingDecorator is null)
        {
            await _next(context);
            return;
        }

        string? key = GenerateClientKey(context);
        ClientStatistics? clientStatistics = await GetClientStatisticsByKey(key);

        if (clientStatistics != null && DateTime.UtcNow < clientStatistics.LastSuccessfulResponseTime.AddSeconds(rateLimitingDecorator.TimeWindow) && clientStatistics.NumberOfRequestsCompletedSuccessfully == rateLimitingDecorator.MaxRequests)
        {
            context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
            return;
        }

        await UpdateClientStatisticsStorage(key, rateLimitingDecorator.MaxRequests);
        await _next(context);
    }

    private static string GenerateClientKey(HttpContext context)
    {
        return $"{context.Request.Path}_{context.Connection.RemoteIpAddress}";
    }

    private async Task<ClientStatistics> GetClientStatisticsByKey(string key)
    {
        return await _cache.GetCacheValueAsync<ClientStatistics>(key);
    }

    private async Task UpdateClientStatisticsStorage(string key, int maxRequests)
    {
        ClientStatistics? clientStat = await _cache.GetCacheValueAsync<ClientStatistics>(key);

        if (clientStat != null)
        {
            clientStat.LastSuccessfulResponseTime = DateTime.UtcNow;

            if (clientStat.NumberOfRequestsCompletedSuccessfully == maxRequests)
            {
                clientStat.NumberOfRequestsCompletedSuccessfully = 1;
            }
            else
            {
                clientStat.NumberOfRequestsCompletedSuccessfully++;
            }

            await _cache.SetCahceValueAsync<ClientStatistics>(key, clientStat);
        }
        else
        {
            ClientStatistics? clientStatistics = new()
            {
                LastSuccessfulResponseTime = DateTime.UtcNow,
                NumberOfRequestsCompletedSuccessfully = 1
            };

            await _cache.SetCahceValueAsync<ClientStatistics>(key, clientStatistics);
        }

    }
}

public class ClientStatistics
{
    public DateTime LastSuccessfulResponseTime { get; set; }
    public int NumberOfRequestsCompletedSuccessfully { get; set; }
}