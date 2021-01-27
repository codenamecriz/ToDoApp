using MediatR;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handlers.Commands
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
