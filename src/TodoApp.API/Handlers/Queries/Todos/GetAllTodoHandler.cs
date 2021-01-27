using AutoMapper;
using MediatR;
using Models.DTOs;
using Serilog;
using Services.Queries.Todos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.API.Data;
using TodoApp.API.Models;

namespace Handlers.Queries
{
    public class GetAllTodoHandler : IRequestHandler<GetAllTodoRequest, IEnumerable<TodoReadDto>>
    {
        private readonly ITodoQueryService _todoQueryService;
        private readonly IMapper _mapper;

        public GetAllTodoHandler(IMapper mapper, ITodoQueryService todoQueryService)
        {

            _mapper = mapper;
            _todoQueryService = todoQueryService;
        }

        public async Task<IEnumerable<TodoReadDto>> Handle(GetAllTodoRequest request, CancellationToken cancellationToken)
        {
            var todoData = await _todoQueryService.GetAllTodoAsync();
            Log.Information("Request All Todo Data From Repository.");
            return  _mapper.Map<IEnumerable<TodoReadDto>>(todoData);
        }
    }
}
