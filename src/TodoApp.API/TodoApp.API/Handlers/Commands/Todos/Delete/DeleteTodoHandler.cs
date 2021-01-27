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
    public class DeleteTodoHandler : IRequestHandler<DeleteTodoRequest, TodoDeleteDto>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public DeleteTodoHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }
        public async Task<TodoDeleteDto> Handle(DeleteTodoRequest request, CancellationToken cancellationToken)
        {
            var todoFromRepo = await _todoRepository.GetTodoById(request.Id);
            if (todoFromRepo != null)
            {
                await _todoRepository.DeleteTodo(todoFromRepo);
                _todoRepository.SaveChanges();
                //    return NoContent();
                //}
                var result = new TodoDeleteDto { Id = request.Id };
                Log.Information("Todo Id:{id} has Successfully Deleted.", request.Id);
                return result;
            }
            Log.Warning("The Todo Request Id:{id} To Delete Not Found.", request.Id);
            return null; 
        }
    }
}
