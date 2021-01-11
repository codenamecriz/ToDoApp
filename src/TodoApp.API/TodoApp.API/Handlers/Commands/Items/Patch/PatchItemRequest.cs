using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.DTOs.Item;

namespace TodoApp.API.Handlers.Commands.Items.Patch
{
    public class PatchItemRequest : IRequest<ItemUpdateDto>
    {
        public int Id { get; set; }
        public ItemUpdateDto ItemToPatch { get; set; }

        public PatchItemRequest(int id, ItemUpdateDto todoDataToUpdate)
        {
            Id = id;
            ItemToPatch = todoDataToUpdate;
        }
    }
}
