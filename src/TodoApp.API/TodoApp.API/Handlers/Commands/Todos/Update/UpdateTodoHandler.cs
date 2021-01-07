using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.API.Data;
using TodoApp.API.DTOs.Todo;
using TodoApp.API.Handlers.Commands.Todos.Update;
using TodoApp.API.Models;

namespace TodoApp.API.Handlers
{
    public class UpdateTodoHandler : IRequestHandler<UpdateTodoRequest, TodoUpdateDto>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public UpdateTodoHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<TodoUpdateDto> Handle(UpdateTodoRequest request, CancellationToken cancellationToken)
        {
            var dataFromRepo = await _todoRepository.GetTodoById(request.Id);
            if (dataFromRepo != null)
            {
                _mapper.Map(request, dataFromRepo);
                await _todoRepository.UpdateTodo(dataFromRepo);
                //    _todoRepo.SaveChanges();
                var result = _mapper.Map<TodoUpdateDto>(request);
                return result;
            }
            return null;
            //return _mapper.Map<TodoUpdateDto>(todoModel);
        }
    }
}
