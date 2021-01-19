﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace TodoApp.API.Data
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _appDbContext;
        public TodoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Todo>> GetAllTodo()
        {
            return await Task.FromResult(_appDbContext.Todos);
        }
        public async Task< Todo> GetTodoById(int id)
        {
            return await Task.FromResult( _appDbContext.Todos.Find(id));
        }
        public async Task CreateTodo(Todo data)
        {
         
            await Task.FromResult( _appDbContext.Add(data));
        }
        public async Task UpdateTodo(Todo data)
        {
            await Task.Delay(1);
           
        }
        public async Task DeleteTodo(Todo data)
        {            
            await Task.FromResult( _appDbContext.Todos.Remove(data));
        }
        public bool SaveChanges()
        {
            return (_appDbContext.SaveChanges() >= 0); 
        }
    }
}
