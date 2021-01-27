using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Services.IRepository;
using TodoApp.API.Models;

namespace Services.Commands.Todos
{
    public class TodoCommandService : ITodoCommandService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IDbAuthentication _dbAuthentication;
        public TodoCommandService(ITodoRepository todoRepository, IDbAuthentication dbAuthentication)
        {
            _todoRepository = todoRepository;
            _dbAuthentication = dbAuthentication;
        }

        public async Task<Todo> CreateTodoAsync(Todo data)
        {
            var result = _dbAuthentication.CheckingIfExist(data);
            if (result.Result == 1)
            {
                Log.Warning("Error:(CREATE) Name: {name} -> The Data that you what to Create Have Matches in Database.", data.Id, data.Name);
                return null;
            }
            await _todoRepository.CreateTodo(data);
            _todoRepository.SaveChanges();
            return data;

        }

        public async Task DeleteTodoAsync(Todo data)
        {
            var result = _dbAuthentication.CheckingIfExist(data);
            if (result.Result == 1)
            {
                await _todoRepository.DeleteTodo(data);
                _todoRepository.SaveChanges();
            }
            else
            {
                Log.Warning("Error:(DELETE) Id: {id} and Name: {name} -> The Data that you what to Delete. Not Found in Database.", data.Id, data.Name);
            }

        }

        public async Task UpdateTodoAsync(Todo data)
        {
            var result = _dbAuthentication.CheckingIfExist(data);
            if (result.Result == 1)
            {
                await _todoRepository.UpdateTodo(data);
                _todoRepository.SaveChanges();
            }
            else 
            {
                Log.Warning("Error:(UPDATE) Id: {id} and Name: {name} -> The Data that you what to Update. Not Found in Database.", data.Id, data.Name);
            }
        }
    }
}
