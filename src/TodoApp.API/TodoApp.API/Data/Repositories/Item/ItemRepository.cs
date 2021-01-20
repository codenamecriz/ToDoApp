using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace TodoApp.API.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetTodoItemsById(int id)
        {
    
            return await Task.FromResult(_context.Items.Where(item => item.TodoId == id));
        }
        public async Task<Item> GetItemById(int id)
        {
            return await Task.FromResult(_context.Items.Find(id));
        }

        public async Task CreateItem(Item data)
        {
            await Task.FromResult(_context.Add(data));
        }
        public async Task UpdateItem(Item data)
        {
            await Task.Delay(1);
        }
        public async Task DeleteItem(Item data)
        {
            await Task.FromResult(_context.Items.Remove(data));
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        
    }
}
