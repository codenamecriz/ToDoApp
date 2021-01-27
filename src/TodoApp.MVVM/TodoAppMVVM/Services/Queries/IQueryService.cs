using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.MVVM.Models;

namespace TodoApp.MVVM.Services
{
    public interface IQueryService
    {
        Task<List<TodoListDTO>> GetAll();
        Task<List<ItemDTO>> GetItemById(int id);
    }
}