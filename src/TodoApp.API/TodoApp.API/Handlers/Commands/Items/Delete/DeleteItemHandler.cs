using AutoMapper;
using MediatR;
using Models.DTOs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.IRepository;

namespace Handlers.Commands
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemRequest, ItemDeleteDto>
    {
        private readonly IItemRepository _itemRepository;
        //private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public DeleteItemHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<ItemDeleteDto> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
        {
            var itemFromRepo = await _itemRepository.GetItemById(request.Id);
            if (itemFromRepo != null)
            {
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
