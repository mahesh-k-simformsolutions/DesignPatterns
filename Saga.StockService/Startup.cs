using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Saga.StockService.Consumer;
using Saga.StockService.Data;
using Saga.StockService.Service;
using System.Reflection;

namespace Saga.StockService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            _ = services.AddCors();
            _ = services.AddControllers();
            _ = services.AddScoped<IStockService, StockService.Service.StockService>();
            _ = services.AddSwaggerGen();

            _ = services.AddSingleton<IBus>(RabbitHutch.CreateBus("host=localhost;username=guest;password=guest"));
            _ = services.AddSingleton<MessageDispatcher>();

            _ = services.AddSingleton<AutoSubscriber>(_ =>
            {
                return new AutoSubscriber(_.GetRequiredService<IBus>(), Assembly.GetExecutingAssembly().GetName().Name)
                {
                    AutoSubscriberMessageDispatcher = _.GetRequiredService<MessageDispatcher>()
                };
            });
            _ = services.AddScoped<OrderCreatedEventConsumer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _ = app.ApplicationServices.GetRequiredService<AutoSubscriber>().SubscribeAsync(new Assembly[] { Assembly.GetExecutingAssembly() });

            _ = app.UseSwagger();

            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }
            _ = app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SAGA pattern v1");
                c.RoutePrefix = string.Empty;
            });

            _ = app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            _ = app.UseHttpsRedirection();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
            });
        }
    }
}
