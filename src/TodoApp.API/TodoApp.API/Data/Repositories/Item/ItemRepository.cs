using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace TodoApp.API.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _appDbContext;
        public ItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Item>> GetTodoItemsById(int id)
        {
            //await Task.Delay(1);
            //return await Task.FromResult( _appDbContext.Items.Find(id));

            return await Task.FromResult(_appDbContext.Items.Where(item => item.TodoId == id));
        }
        public async Task<Item> GetItemById(int id)
        {
            return await Task.FromResult(_appDbContext.Items.Find(id));
        }

        public async Task CreateItem(Item data)
        {
            await Task.FromResult(_appDbContext.Add(data));
        }
        public async Task UpdateItem(Item data)
        {
            await Task.Delay(1);
        }
        public async Task DeleteItem(Item data)
        {
            await Task.FromResult(_appDbContext.Items.Remove(data));
        }

        public bool SaveChanges()
        {
            return (_appDbContext.SaveChanges() >= 0);
        }

        
    }
}
