using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace Services.Queries.Todos
{
    public interface ITodoQueryService
    {
        Task<IEnumerable<Todo>> GetAllTodoAsync();
        Task<Todo> GetTodoByIdAsync(int id);
     
    }
}
