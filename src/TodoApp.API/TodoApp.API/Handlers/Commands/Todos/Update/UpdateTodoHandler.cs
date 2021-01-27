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
using TodoApp.API.Models;

namespace Handlers.Commands
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
                //Console.WriteLine(request.);
                _mapper.Map(request.TodoDataToUpdate, dataFromRepo);
                await _todoRepository.UpdateTodo(dataFromRepo);
                _todoRepository.SaveChanges();
                var result = _mapper.Map<TodoUpdateDto>(request.TodoDataToUpdate);
                //var result = new TodoUpdateDto { Name = dataFromRepo.Name, Description = dataFromRepo.Description };
                Log.Information("Request Todo Id:{id} Successfully Updated.",request.Id);
                return result;
            }
            Log.Warning("Request Todo Id:{id} To Update Not Found.",request.Id);
            return null;
            //return _mapper.Map<TodoUpdateDto>(todoModel);
        }
    }
}
