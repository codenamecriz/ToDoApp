using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace TodoApp.API.Services.Queries
{
    public class GetTodoByIdQuery : IRequest<TodoReadDto>
    {
        public int Id { get; }

        public GetTodoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
