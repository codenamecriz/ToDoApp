using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Services.IRepository;
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

       

        public async Task<IEnumerable<GetItemDto>> GetTodoItemsByIdAsync(GetItemQuery queryId)
        {
            if (queryId.Id > 0)
            {
                var result =  await _itemRepository.GetTodoItemsById(queryId.Id);
                var response = new List<GetItemDto>();
                foreach(var item in  result)
                {
                    response.Add(new GetItemDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Details = item.Details,
                        Status = item.Status
                        
                    });
                }
                return response;
            }
            return null;
        }

        public async Task<GetItemDto> GetItemByIdAsync(GetItemQuery queryId)
        {
            //var itemId = new Item { Id = queryId.Id };
            if (queryId.Id > 0)
            {
                 var result = await _itemRepository.GetItemById(queryId.Id);
                var reponse = new GetItemDto 
                {
                    Id = result.Id,
                    Name = result.Name,
                    Details = result.Details
                };
                return reponse;
            }
            return null;
        }
    }
}
