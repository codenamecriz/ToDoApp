using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.DTOs.Item;
using TodoApp.API.Models;

namespace TodoApp.API.Handlers.Queries.Items
{
    public class GetTodoItemsByIdRequest : IRequest<IEnumerable<ItemResponseDto>>
    {
        public int Id { get; }

        public GetTodoItemsByIdRequest(int id)
        {
            Id = id;
        }
    }
}
