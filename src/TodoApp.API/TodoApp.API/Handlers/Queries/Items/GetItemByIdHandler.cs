using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.API.Data;
using TodoApp.API.Models;

namespace TodoApp.API.Handlers.Queries.Items
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdRequest, ItemReadDto>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemByIdHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<ItemReadDto> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
        {
            var itemFromRepo = await _itemRepository.GetItemById(request.Id);
            return itemFromRepo != null ? _mapper.Map<ItemReadDto>(itemFromRepo) : null;
        }
    }
}
