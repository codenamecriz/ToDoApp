using System.Threading.Tasks;
using TodoApp.API.Models;

namespace Services.Commands.Todos
{
    public interface ITodoCommandService
    {
        Task<Todo> CreateTodoAsync(Todo data);
        Task UpdateTodoAsync(Todo data);
        Task DeleteTodoAsync(Todo data);
    }
}