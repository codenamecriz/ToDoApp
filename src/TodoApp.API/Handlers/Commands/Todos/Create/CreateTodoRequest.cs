using MediatR;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace Handlers.Commands
{
    public class CreateTodoRequest : IRequest<TodoReadDto>
    {
        //public int Id { get; set; }
  
        public string Name { get; set; }
        
        public string Description { get; set; }//
    }
}
