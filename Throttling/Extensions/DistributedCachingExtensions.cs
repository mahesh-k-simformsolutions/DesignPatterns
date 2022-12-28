using Microsoft.Extensions.Caching.Distributed;

namespace Throttling.Extensions;

public static class DistributedCachingExtensions
{
    public static async Task SetCahceValueAsync<T>(this IDistributedCache distributedCache, string key, T value, CancellationToken token = default)
    {
        await distributedCache.SetAsync(key, value.ToByteArray(), token);
    }

    public static async Task<T> GetCacheValueAsync<T>(this IDistributedCache distributedCache, string key, CancellationToken token = default) where T : class
    {
        byte[]? result = await distributedCache.GetAsync(key, token);
        return result.FromByteArray<T>();
    }
}

