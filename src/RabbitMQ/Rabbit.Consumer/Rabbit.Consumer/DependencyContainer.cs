using Domain;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rabbit.Consumer
{
    public class DependencyContainer //: IHostedService
    {
        //public IConfiguration Configuration { get; }
        //public DependencyContainer(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public void RegisterServices(IServiceCollection services, HostBuilderContext context)
        {
            //ConfigureServices((context, services) =>
            // {
            services.AddScoped<IRabbitMQService, RabbitMQService>();
            services.AddScoped<IConsumerMassTransitConfig, ConsumerMassTransitConfig>();
            services.AddMassTransit(config => //);// 
            {
                config.AddConsumer<OrderConsumer>();
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("amqp://guest:guest@localhost:5672");
                    cfg.ReceiveEndpoint("test-queue", c => { c.ConfigureConsumer<OrderConsumer>(ctx); });
                });
            });
            services.AddMassTransitHostedService();
              //});
        }

        //public Task StartAsync(CancellationToken cancellationToken)
        //{
        //    var bus = Bus.Factory.CreateUsingRabbitMq(config =>
        //    {
        //        config.Host("amqp://guest:guest@localhost:5672");
        //        config.ReceiveEndpoint("order-queue", c =>
        //        {
        //            c.Handler<Order>(ctx =>
        //            {
        //                return Console.Out.WriteLineAsync(ctx.Message.Name);
        //            });
        //        });
        //    });
        //    bus.Start();

        //    //bus.Publish(new Order { Name = "Test Name" });
        //    return Task.CompletedTask;
        //}
    

        //public Task StopAsync(CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
