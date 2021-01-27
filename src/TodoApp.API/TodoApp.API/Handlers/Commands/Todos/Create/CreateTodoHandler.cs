using AutoMapper;
using MediatR;
using Models.DTOs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.IRepository;
using TodoApp.API.Models;

namespace Handlers.Commands
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
           
                var todoModel = _mapper.Map<Todo>(request);
                await _todoRepository.CreateTodo(todoModel);
                _todoRepository.SaveChanges();
                Log.Information("New Todo Successfully Created Id:{id}",todoModel.Id);
                return _mapper.Map<TodoReadDto>(todoModel);
                
            
            //Log.Warning("Request must Required Name:{name} and Description:{description}", request.Name, request.Description);
            ////Log.CloseAndFlush();
            //return null;


        }
    }
}
