using AutoMapper;
using MediatR;
using Models.DTOs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Services.IRepository;
using TodoApp.API.Models;
using Services.Commands.Todos;

namespace Handlers.Commands
{
    public class CreateTodoHandler : IRequestHandler<CreateTodoRequest, TodoReadDto>
    {
        private readonly ITodoCommandService _todoCommandService;
        private readonly IMapper _mapper;
        public CreateTodoHandler(IMapper mapper, ITodoCommandService todoCommandService)
        {

            _mapper = mapper;
            _todoCommandService = todoCommandService;
        }


        public async Task<TodoReadDto> Handle(CreateTodoRequest request, CancellationToken cancellationToken)
        {
           
                var todoModel = _mapper.Map<Todo>(request);
                await _todoCommandService.CreateTodoAsync(todoModel);
                Log.Information("New Todo Successfully Created Id:{id}",todoModel.Id);
                return _mapper.Map<TodoReadDto>(todoModel);
                
            
            //Log.Warning("Request must Required Name:{name} and Description:{description}", request.Name, request.Description);
            ////Log.CloseAndFlush();
            //return null;


        }
    }
}
