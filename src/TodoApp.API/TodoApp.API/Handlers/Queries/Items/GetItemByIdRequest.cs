using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace TodoApp.API.Handlers.Queries.Items
{
    public class GetItemByIdRequest : IRequest<ItemReadDto>
    {
        public int Id { get; }

        public GetItemByIdRequest(int id)
        {
            Id = id;
        }
    }
}
