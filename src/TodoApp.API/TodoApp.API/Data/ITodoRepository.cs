using System.Collections.Generic;
using TodoApp.API.Models;

namespace TodoApp.API.Data
{
    public interface ITodoRepository
    {
        Todo GetListById(int id);
        IEnumerable<Todo> GetList();
        void CreateTodo(Todo data);
        void UpdateTodo(Todo data);
        void DeleteTodo(Todo data);
        bool SaveChanges();

    }
}