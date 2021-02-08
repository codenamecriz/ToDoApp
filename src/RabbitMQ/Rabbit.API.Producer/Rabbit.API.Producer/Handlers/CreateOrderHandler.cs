using Domain;
using MassTransit;
using MediatR;
using Rabbit.API.Producer.Notifications;
using Rabbit.API.Producer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rabbit.API.Producer.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest>
    {
        //private readonly CommandService _commandService;
        private readonly IMediator _mediator;
        //private readonly IPublishEndpoint _publishEndpoint;
        public CreateOrderHandler(IMediator mediator)
        {
            //_commandService = new CommandService();
            _mediator = mediator;
            //_publishEndpoint = publishEndpoint;
        }
        public async Task<Unit> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            //_commandService.Create(request);
            //_publishEndpoint.Publish<Order>(values);

            Console.WriteLine("------Handler------>" + request);
            //var @event = new CreateOrderRequest();
            //@event.Id = request.Id;

            await _mediator.Publish(new OrderPlacedEvent { Id = request.Id}, cancellationToken);

            return Unit.Value;
        }
    }
}
