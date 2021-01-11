using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.DTOs.Item;

namespace TodoApp.API.Handlers.Commands.Items.Update
{
    public class UpdateItemRequest : IRequest<ItemUpdateDto>
    {
        public int Id { get; set; }
        public ItemUpdateDto ItemToUpdate { get; set; }
        public UpdateItemRequest(int id, ItemUpdateDto itemToUpdate)
        {
            Id = id;
            ItemToUpdate = itemToUpdate;
        }
    }
}
