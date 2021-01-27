using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.IRepository;
using TodoApp.API.Models;

namespace Services.Queries.Items
{
    public class ItemQueryService : IItemQueryService
    {
        private readonly IItemRepository _itemRepository;

        public ItemQueryService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            if (id > 0)
            {
                return await _itemRepository.GetItemById(id);
            }
            return null;
        }

        public async Task<IEnumerable<Item>> GetTodoItemsByIdAsync(int id)
        {
            if (id > 0)
            {
                return await _itemRepository.GetTodoItemsById(id);
            }
            return null;
        }
    }
}
