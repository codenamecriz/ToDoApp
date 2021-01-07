using AutoMapper;
using MediatR;
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
            var todoModel = _mapper.Map<Todo>(request);
            await _todoRepository.CreateTodo(todoModel);
            return _mapper.Map<TodoReadDto>(todoModel);
        }
    }
}
