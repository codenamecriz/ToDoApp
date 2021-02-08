using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rabbit.API.Producer.Notifications
{
    public class OrderingEventsClientDispatcher : INotificationHandler<OrderPlacedEvent>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public OrderingEventsClientDispatcher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public Task Handle(OrderPlacedEvent @event, CancellationToken cancellationToken)
        {

            Console.WriteLine("___> INotification data: " + @event.Id);
            return _publishEndpoint.Publish<OrderPlacedEvent>(@event);
            //var bus = Bus.Factory.CreateUsingRabbitMq(config =>
            //{
            //    config.Host("amqp://guest:guest@localhost:5672");
            //    config.ReceiveEndpoint("test-queue", c =>
            //    {
            //        c.Handler<OrderPlacedEvent>(ctx =>
            //        {
            //            return Console.Out.WriteLineAsync(ctx.MessageId.ToString());
            //        });
            //    });
            //});
            //bus.Start();
            //return bus.Publish(new OrderPlacedEvent { Id = @event.Id });
        }

    
    }
}
