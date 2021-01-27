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

namespace Handlers.Commands
{
    public class PatchTodoHandler : IRequestHandler<PatchTodoRequest, TodoUpdateDto>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public PatchTodoHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }
        public async Task<TodoUpdateDto> Handle(PatchTodoRequest request, CancellationToken cancellationToken)
        {

            var todoFromRepo = await _todoRepository.GetTodoById(request.Id);
            if (todoFromRepo == null)
            {
                Log.Warning("Todo Id:{id} Requested Not Found.",request.Id);
                return null;
            }
       
            var todoToPatch = _mapper.Map<TodoUpdateDto>(todoFromRepo);
            if (request.TodoToPatch == null)
            {
                return todoToPatch;
            }

            var check = _mapper.Map(request.TodoToPatch, todoFromRepo);
           
            await _todoRepository.UpdateTodo(todoFromRepo);
            _todoRepository.SaveChanges();
            Log.Information("Todo Id:{id} Successfully Patched", request.Id);
            return null;
            
        }
    }
}
