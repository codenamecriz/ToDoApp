using MediatR;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handlers.Commands
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
