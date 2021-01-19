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
using TodoApp.API.Enum;
using TodoApp.API.Models;

namespace TodoApp.API.Handlers.Queries.Items
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdRequest, ItemResponseDto>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemByIdHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<ItemResponseDto> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
        {
            var itemFromRepo = await _itemRepository.GetItemById(request.Id);
            
            Log.Information("Request Item where Primary Key = {id} From Repository.",request.Id);
            return itemFromRepo != null ? _mapper.Map<ItemResponseDto>(itemFromRepo) : null;
        }
    }
}
