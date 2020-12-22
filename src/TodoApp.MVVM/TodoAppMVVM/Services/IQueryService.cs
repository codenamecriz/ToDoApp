using System.Collections.Generic;
using TodoApp.MVVM.Models;

namespace TodoApp.MVVM.Services
{
    public interface IQueryService
    {
        List<TodoListDTO> GetAll();
        List<ItemDTO> GetItemById(int id);
    }
}