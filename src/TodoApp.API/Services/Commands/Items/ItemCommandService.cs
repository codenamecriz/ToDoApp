using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Services.IRepository;
using TodoApp.API.Models;
using Services.Commands.Items.Request;

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

        public async Task<ResponseItemDto> CreateItemAsync(CreateItemCommand data)
        {
            BaseCommand baseCmd = new BaseCommand {Name = data.Name };
            var response = new ResponseItemDto(0);
            var result = _dbAuthentication.CheckingIfExist(baseCmd);
            if (result.Result == 1)
            {
                Log.Warning("Error:(CREATE) Name: {name} -> The 'ITEM' that you what to Create Have Matches in Database.",  data.Name);
                return response;
            }
            Item itemModel = new Item 
            {
                Name = data.Name ,
                Details = data.Details,
                Status = data.Status,
                TodoId = data.TodoId
            };
            await _itemRepository.CreateItem(itemModel);
            _itemRepository.SaveChanges();

            response = new ResponseItemDto(itemModel.Id);
            Console.WriteLine(itemModel.Id);
            Console.WriteLine(response.Id);
            return response;
        }

        
        public async Task UpdateItemAsync(UpdateItemCommand data)
        {
            BaseCommand baseCmd = new BaseCommand { Name = data.Name };
            var result = _dbAuthentication.CheckingIfExist(baseCmd);
            if (result.Result == 1)
            {
                Item itemModel = new Item
                {
                    Name = data.Name,
                    Details = data.Details,
                    Status = data.Status,
                };
                await _itemRepository.UpdateItem(itemModel);
                _itemRepository.SaveChanges();
            }
            else
            {
                Log.Warning("Error:(UPDATE) Id: {id} and Name: {name} -> The 'ITEM' that you what to Update. Not Found in Database.", data.Id, data.Name);
            }
        }

        public async Task DeleteItemAsync(DeleteItemCommand data)
        {
            BaseCommand baseCmd = new BaseCommand { Name = data.Name };
            var result = _dbAuthentication.CheckingIfExist(baseCmd);
            if (result.Result == 1)
            {
                Item itemModel = new Item
                {
                    Id = data.Id,
                    Name = data.Name,
                    Details = data.Details,
                    Status = data.Status,
                    TodoId = data.TodoId
                    
                };
                await _itemRepository.DeleteItem(itemModel);
                _itemRepository.SaveChanges();
            }
            else
            {
                Log.Warning("Error:(DELETE) Id: {id} and Name: {name} -> The 'ITEM' that you what to Delete. Not Found in Database.", data.Id, data.Name);
            }
        }
    }
}
