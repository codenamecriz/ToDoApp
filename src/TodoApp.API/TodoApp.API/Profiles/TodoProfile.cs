using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.DTOs;
using TodoApp.API.DTOs.Todo;
using TodoApp.API.Models;

namespace TodoApp.API.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            // Source -> Target
            CreateMap<Todo, TodoReadDto>();
            CreateMap<TodoCreateDto, Todo>();
            CreateMap<TodoUpdateDto, Todo>();
            CreateMap<Todo, TodoUpdateDto>();
        }
    }
}
