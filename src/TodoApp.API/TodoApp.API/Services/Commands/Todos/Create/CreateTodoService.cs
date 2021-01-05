using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace TodoApp.API.Services.Commands.Todos.Create
{
    public class CreateTodoService : IRequest<TodoReadDto>
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
