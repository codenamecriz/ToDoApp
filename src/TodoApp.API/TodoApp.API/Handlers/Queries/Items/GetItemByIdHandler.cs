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
using TodoApp.API.Enum;
using TodoApp.API.Models;

namespace Handlers.Queries
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
