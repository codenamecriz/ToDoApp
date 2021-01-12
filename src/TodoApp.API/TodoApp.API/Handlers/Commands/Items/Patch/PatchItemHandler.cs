using AutoMapper;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.API.Data;
using TodoApp.API.DTOs.Item;

namespace TodoApp.API.Handlers.Commands.Items.Patch
{
    public class PatchItemHandler : IRequestHandler<PatchItemRequest, ItemUpdateDto>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public PatchItemHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<ItemUpdateDto> Handle(PatchItemRequest request, CancellationToken cancellationToken)
        {
            var itemFromRepo = await _itemRepository.GetItemById(request.Id);
            if (itemFromRepo == null)
            {
                Log.Warning("Item Id:{id} Requested Not Found.", request.Id);
                return null;
            }
            var todoToPatch = _mapper.Map<ItemUpdateDto>(itemFromRepo);
            if (request.ItemToPatch == null)
            {
                return todoToPatch;
            }

            var check = _mapper.Map(request.ItemToPatch, itemFromRepo);

            await _itemRepository.UpdateItem(itemFromRepo);
            _itemRepository.SaveChanges();
            Log.Information("Item Id:{id} Successfully Patched.", request.Id);
            return null;
        }
    }
}
