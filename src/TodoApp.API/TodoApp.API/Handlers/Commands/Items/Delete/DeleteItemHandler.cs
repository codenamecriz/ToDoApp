using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.API.Data;
using TodoApp.API.DTOs.Item;

namespace TodoApp.API.Handlers.Commands.Items.Delete
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemRequest, ItemDeleteDto>
    {
        private readonly IItemRepository _itemRepository;
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
                return result;
            }
            return null; ;
        }
    }
}
