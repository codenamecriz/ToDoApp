using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.DTOs.Todo;

namespace TodoApp.API.Handlers.Commands.Todos.Update
{
    public class UpdateTodoRequest : IRequest<TodoUpdateDto>
    {
        //public int Id { get; set; }
        //public string Name { get; set; }

        //public string Description { get; set; }//

        //public UpdateTodoRequest(int id, string name, string description)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //}

        public int Id { get; set; }
        public TodoUpdateDto TodoDataToUpdate { get; set; }
        public UpdateTodoRequest(int id, TodoUpdateDto todoDataToUpdate)
        {
            Id = id;
            TodoDataToUpdate = todoDataToUpdate;
        }
    }
}
