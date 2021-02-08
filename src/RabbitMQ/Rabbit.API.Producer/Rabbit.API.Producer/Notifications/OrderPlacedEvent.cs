using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Rabbit.API.Producer.Notifications
{
    public class OrderPlacedEvent : INotification
    {
        public int Id { get; set; }

    }
}
