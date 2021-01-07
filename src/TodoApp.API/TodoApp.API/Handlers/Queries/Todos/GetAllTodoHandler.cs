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
    public class GetAllTodoHandler : IRequestHandler<GetAllTodoRequest, IEnumerable<TodoReadDto>>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public GetAllTodoHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TodoReadDto>> Handle(GetAllTodoRequest request, CancellationToken cancellationToken)
        {
            var todoData = await _todoRepository.GetAllTodo();
            return  _mapper.Map<IEnumerable<TodoReadDto>>(todoData);
        }
    }
}
