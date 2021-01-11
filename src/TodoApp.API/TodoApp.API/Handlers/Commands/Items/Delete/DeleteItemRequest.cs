using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.DTOs.Item;

namespace TodoApp.API.Handlers.Commands.Items.Delete
{
    public class DeleteItemRequest : IRequest<ItemDeleteDto>
    {
        public int Id { get; set; }
        public DeleteItemRequest(int id)
        {
            Id = id;
        }
    }
}
