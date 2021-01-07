using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace TodoApp.API.Data
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllTodo();
        Task<Todo> GetTodoById(int id);
        
        Task CreateTodo(Todo data);
        Task UpdateTodo(Todo data);
        void DeleteTodo(Todo data);
        bool SaveChanges();

    }
}