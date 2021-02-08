using Domain;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbit.Consumer
{
    public class ConsumerMassTransitConfig : IConsumerMassTransitConfig
    {
        public void RabbitToMassTransit()
        {
            //    var bus = Bus.Factory.CreateUsingRabbitMq(config =>
            //    {
            //        config.Host("amqp://guest:guest@localhost:5672");
            //        config.ReceiveEndpoint("test-queue", c =>
            //        {
            //            c.Handler<Order>(ctx =>
            //            {
            //                return Console.Out.WriteLineAsync(ctx.Message.Name);
            //            });
            //        }); 
            //    });
            //    bus.Start();
            //    bus.Publish(new Order { Name = "Test Name" });
            //}
        }
    }
}
