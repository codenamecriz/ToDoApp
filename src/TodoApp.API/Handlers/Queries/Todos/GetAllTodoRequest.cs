using MediatR;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace Handlers.Queries
{
    public class GetAllTodoRequest : IRequest<IEnumerable<TodoReadDto>>
    {
    }
}
