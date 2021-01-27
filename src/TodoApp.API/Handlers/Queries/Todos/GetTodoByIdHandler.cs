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
    public class GetTodoByIdHandler : IRequestHandler<GetTodoByIdRequest, TodoReadDto>
    {
        private readonly ITodoQueryService _todoQueryService;
        private readonly IMapper _mapper;

        public GetTodoByIdHandler(IMapper mapper, ITodoQueryService todoQueryService)
        {

            _mapper = mapper;
            _todoQueryService = todoQueryService;
        }


        public async Task<TodoReadDto> Handle(GetTodoByIdRequest request, CancellationToken cancellationToken)
        {
            var todoData = await _todoQueryService.GetTodoByIdAsync(request.Id);
            Log.Information("Request Todo Id: {id} from Repository.",request.Id);
            return todoData != null ? _mapper.Map<TodoReadDto>(todoData) : null; 
            //if (todoData != null)
            //{
            //    return ;
            //}
            //return NotFound();
        }
    }
}
