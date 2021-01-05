using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.API.Data;
using TodoApp.API.Models;
using TodoApp.API.Services.Queries;

namespace TodoApp.API.Handlers
{
    public class GetTodoByIdHandler : IRequestHandler<GetTodoByIdQuery, TodoReadDto>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public GetTodoByIdHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }


        public async Task<TodoReadDto> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            var todoData = await _todoRepository.GetTodoById(request.Id);
            return todoData != null ? _mapper.Map<TodoReadDto>(todoData) : null; 
            //if (todoData != null)
            //{
            //    return ;
            //}
            //return NotFound();
        }
    }
}
