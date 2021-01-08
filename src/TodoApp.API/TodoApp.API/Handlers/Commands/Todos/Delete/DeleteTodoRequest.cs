using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.DTOs.Todo;

namespace TodoApp.API.Handlers.Commands.Todos.Delete
{
    public class DeleteTodoRequest : IRequest<TodoDeleteDto>
    {
        public int Id { get; set; }
        public DeleteTodoRequest(int id)
        {
            Id = id;
        }

    }
}
