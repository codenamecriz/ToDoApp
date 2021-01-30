using AutoMapper;
using MediatR;
using Models.DTOs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Services.IRepository;
using Services.Commands.Items;
using Services.Queries.Items;
using TodoApp.API.Models;
using Services.Commands.Items.Request;

namespace Handlers.Commands
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemRequest, ItemDeleteDto> 
    {
        //private readonly IItemCommandService _itemCommandService;
        //private readonly IItemQueryService _itemQueryService;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public DeleteItemHandler(IItemRepository itemRepository, IMapper mapper)//, IItemQueryService itemQueryService)
        {
            //_itemCommandService = itemCommandService;
            _itemRepository = itemRepository;
            _mapper = mapper;
            //_itemQueryService = itemQueryService;
        }
        public async Task<ItemDeleteDto> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
        {
            //GetItemQuery itemId = new GetItemQuery(request.Id);

            //var itemFromRepo = await _itemQueryService.GetItemByIdAsync(itemId);
            var itemFromRepo = await _itemRepository.GetItemById(request.Id);
            if (itemFromRepo != null)
            {
                //var deleteItem = new Item 
                //{ 
                //    Id = itemFromRepo.Id,
                //    Name = itemFromRepo.Name,
                //    Details = itemFromRepo.Details,
                //    Status = itemFromRepo.Status
                //};
                //await _itemCommandService.DeleteItemAsync(deleteItem);
                await _itemRepository.DeleteItem(itemFromRepo);
                _itemRepository.SaveChanges();
                var result = new ItemDeleteDto { Id = request.Id };
                Log.Information("Item Id:{id} has Successfully Deleted.", request.Id);
                return result;
            }
            Log.Warning("The Request Item Id:{id} To Delete Not Found.", request.Id);
            return null; ;
        }
    }
}
