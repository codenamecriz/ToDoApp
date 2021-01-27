using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.MVVM.Models;

namespace TodoApp.MVVM.Helpers.RequestApi.RequestQueries.RequestTodo
{
    public interface ITodoGetRequest
    {
        Task<IEnumerable<TodoListDTO>> GetAllTodoAsync();

        Task<TodoListDTO> GetTodoByIdAsync(int id);
    }
}