using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace TodoApp.API.Data
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext appDbContext;
        public TodoRepository(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public IEnumerable<Todo> GetList()
        {
            return appDbContext.Todos;
        }
        public Todo GetListById(int id)
        {
            return appDbContext.Todos.Find(id);
        }
        public void CreateTodo(Todo data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            appDbContext.Add(data);
        }
        public void UpdateTodo(Todo data)
        {
            //throw new NotImplementedException();
        }
        public void DeleteTodo(Todo data)
        {

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            appDbContext.Todos.Remove(data);
        }
        public bool SaveChanges()
        {
            return (appDbContext.SaveChanges() >= 0); 
        }

       
    }
}
