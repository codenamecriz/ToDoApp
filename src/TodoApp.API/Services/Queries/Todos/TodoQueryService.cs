using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.IRepository;
using TodoApp.API.Models;

namespace Services.Queries.Todos
{
    public class TodoQueryService : ITodoQueryService
    {

        private readonly ITodoRepository _todoRepository;

        public TodoQueryService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<Todo>> GetAllTodoAsync()
        {
            return await _todoRepository.GetAllTodo();
        }

        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            if (id >= 0)
            {
                return await _todoRepository.GetTodoById(id);
            }
            return null;
                
        }

      
    }
}
