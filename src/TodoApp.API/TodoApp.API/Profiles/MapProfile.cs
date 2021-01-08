using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.DTOs;
using TodoApp.API.DTOs.Todo;
using TodoApp.API.Handlers.Commands.Todos.Update;
using TodoApp.API.Models;
using TodoApp.API.Services.Commands.Todos.Create;

namespace TodoApp.API.Profiles
{
    public class MapProfile : AutoMapper.Profile
    {
        public MapProfile()
        {
            // Source -> Target
            CreateMap<Todo, TodoReadDto>();
            CreateMap<Todo, TodoUpdateDto>();
            CreateMap<TodoCreateDto, Todo>();
            CreateMap<TodoUpdateDto, Todo>();
            
            CreateMap<CreateTodoRequest, Todo>(); // Create
            CreateMap<UpdateTodoRequest, Todo>(); // Update
            CreateMap<TodoUpdateDto, UpdateTodoRequest>(); // Update
            CreateMap<UpdateTodoRequest, TodoUpdateDto>(); // Update
        }
    }
}
