using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace TodoApp.API.Services.Commands.Todos.Create
{
    public class CreateTodoService : IRequest<TodoReadDto>
    {
        //public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }//
    }
}
