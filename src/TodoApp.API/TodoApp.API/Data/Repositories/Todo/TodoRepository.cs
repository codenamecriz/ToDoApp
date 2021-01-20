using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace TodoApp.API.Data
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;
        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Todo>> GetAllTodo()
        {
            return await Task.FromResult(_context.Todos);
        }
        public async Task< Todo> GetTodoById(int id)
        {
            return await Task.FromResult(_context.Todos.Find(id));
        }
        public async Task CreateTodo(Todo data)
        {
         
            await Task.FromResult(_context.Add(data));
        }
        public async Task UpdateTodo(Todo data)
        {
            await Task.Delay(1);
           
        }
        public async Task DeleteTodo(Todo data)
        {            
            await Task.FromResult(_context.Todos.Remove(data));
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); 
        }
    }
}
