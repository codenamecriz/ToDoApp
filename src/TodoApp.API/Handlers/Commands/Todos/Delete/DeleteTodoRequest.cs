using MediatR;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handlers.Commands
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
