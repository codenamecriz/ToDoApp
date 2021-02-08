using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rabbit.API.Producer.Services
{
   
    public class CommandService
    {
        private readonly List<Order> ListContainer = new List<Order>();

        public int Create(Order order)
        {
            ListContainer.Add(order);
            return order.Id;
        }
    }
}
