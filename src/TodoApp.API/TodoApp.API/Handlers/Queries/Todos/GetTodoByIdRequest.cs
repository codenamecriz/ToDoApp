using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace TodoApp.API.Services.Queries
{
    public class GetTodoByIdRequest : IRequest<TodoReadDto>
    {
        public int Id { get; }

        public GetTodoByIdRequest(int id)
        {
            Id = id;
        }
    }
}
