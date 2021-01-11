using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.DTOs;
using TodoApp.API.Models;

namespace TodoApp.API.Handlers.Commands.Items.Create
{
    public class CreateItemRequest : IRequest<ItemCreateDto>
    {

        public string Name { get; set; }
        public string Detailed { get; set; }
        public string Status { get; set; }
        public string TodoId { get; set; }
    }
}
