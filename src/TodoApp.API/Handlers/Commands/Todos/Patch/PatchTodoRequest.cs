using MediatR;
using Models.DTOs;
//using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handlers.Commands
{
    public class PatchTodoRequest : IRequest<TodoUpdateDto>
    {
        public int Id { get; set; }
        public TodoUpdateDto TodoToPatch { get; set; }

        public PatchTodoRequest(int id, TodoUpdateDto todoDataToUpdate)
        {
            Id = id;
            TodoToPatch = todoDataToUpdate;
        }
        //-----------------
        //public int Id { get; set; }
        //public string Name { get; set; }

        //public string Description { get; set; }//

        //public PatchTodoRequest(int id, string name, string description)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //}
        //====================================
        //public int Id { get; set; }
        //public JsonPatchDocument<TodoUpdateDto> PathDoc { get; set; }


        //public PatchTodoRequest(int id, JsonPatchDocument<TodoUpdateDto> pathDoc)
        //{
        //    Id = id;
        //    PathDoc = pathDoc;


        //}
    }
}
