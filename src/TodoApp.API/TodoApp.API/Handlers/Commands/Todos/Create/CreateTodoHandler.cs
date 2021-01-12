using AutoMapper;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.API.Data;
using TodoApp.API.DTOs;
using TodoApp.API.Models;
using TodoApp.API.Services.Commands.Todos.Create;

namespace TodoApp.API.Handlers
{
    public class CreateTodoHandler : IRequestHandler<CreateTodoRequest, TodoReadDto>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;
        public CreateTodoHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }


        public async Task<TodoReadDto> Handle(CreateTodoRequest request, CancellationToken cancellationToken)
        {
           
            if (request.Name != null && request.Description != null)
            {
                var todoModel = _mapper.Map<Todo>(request);
                await _todoRepository.CreateTodo(todoModel);
                _todoRepository.SaveChanges();
                Log.Information("New Todo Successfully Created Id:{id}",todoModel.Id);
                return _mapper.Map<TodoReadDto>(todoModel);
                
            }
            Log.Warning("Request must Required Name:{name} and Description:{description}", request.Name, request.Description);
            //Log.CloseAndFlush();
            return null;


        }
    }
}
