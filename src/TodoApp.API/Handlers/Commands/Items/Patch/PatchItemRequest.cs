using MediatR;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handlers.Commands
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
