using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.IRepository;
using TodoApp.API.Models;

namespace Services.Commands.Items
{
    public class ItemCommandService : IItemCommandService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IDbAuthentication _dbAuthentication;
        public ItemCommandService(IItemRepository itemRepository, IDbAuthentication dbAuthentication)
        {
            _itemRepository = itemRepository;
            _dbAuthentication = dbAuthentication;
        }

        public async Task<Item> CreateItemAsync(Item data)
        {
            var result = _dbAuthentication.CheckingIfExist(data);
            if (result == 1)
            {
                Log.Warning("Error:(CREATE) Name: {name} -> The 'ITEM' that you what to Create Have Matches in Database.", data.Id, data.Name);
                return null;
            }
            await _itemRepository.CreateItem(data);
            _itemRepository.SaveChanges();
            return data;
        }

        public async Task DeleteItemAsync(Item data)
        {
            var result = _dbAuthentication.CheckingIfExist(data);
            if (result == 1)
            {
                await _itemRepository.DeleteItem(data);
                _itemRepository.SaveChanges();
            }
            else 
            { 
                Log.Warning("Error:(DELETE) Id: {id} and Name: {name} -> The 'ITEM' that you what to Delete. Not Found in Database.", data.Id, data.Name); 
            }
        }
        public async Task UpdateItemAsync(Item data)
        {
            var result = _dbAuthentication.CheckingIfExist(data);
            if (result == 1)
            {
                await _itemRepository.UpdateItem(data);
                _itemRepository.SaveChanges();
            }
            else
            {
                Log.Warning("Error:(UPDATE) Id: {id} and Name: {name} -> The 'ITEM' that you what to Update. Not Found in Database.", data.Id, data.Name);
            }
        }
    }
}
