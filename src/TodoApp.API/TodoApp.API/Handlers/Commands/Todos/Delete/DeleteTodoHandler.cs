using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.API.Data;
using TodoApp.API.DTOs.Todo;

namespace TodoApp.API.Handlers.Commands.Todos.Delete
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
                return result;
            }
            return null; ;
        }
    }
}
