using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.API.Data;
using TodoApp.API.DTOs.Todo;

namespace TodoApp.API.Handlers.Commands.Todos.Put
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
            var todoToPatch = _mapper.Map<TodoUpdateDto>(todoFromRepo);
            if (request.TodoToPatch == null)
            {
                return todoToPatch;
            }

            var check = _mapper.Map(request.TodoToPatch, todoFromRepo);
           
            await _todoRepository.UpdateTodo(todoFromRepo);
            _todoRepository.SaveChanges();
            return null;
            //var todoFromRepo = _todoRepo.GetTodoById(id);
            //if (todoFromRepo != null)
            //{
            //    var todoToPatch = _mapper.Map<TodoUpdateDto>(todoFromRepo);
            //    pathDoc.ApplyTo(todoToPatch, ModelState);

            //    if (!TryValidateModel(todoToPatch))
            //    {
            //        return ValidationProblem(ModelState);
            //    }
            //    _mapper.Map(todoToPatch, todoFromRepo);
            //    _todoRepo.UpdateTodo(todoFromRepo);
            //    _todoRepo.SaveChanges();
            //    return NoContent();
            //}
        }
    }
}
