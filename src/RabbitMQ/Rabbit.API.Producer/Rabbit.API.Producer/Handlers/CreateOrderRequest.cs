using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rabbit.API.Producer.Handlers
{
    public class CreateOrderRequest : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
