using AutoMapper;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.API.Data;
using TodoApp.API.DTOs;
using TodoApp.API.Models;

namespace TodoApp.API.Handlers.Commands.Items.Create
{
    public class CreateItemHandler : IRequestHandler<CreateItemRequest, ItemCreateDto>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public CreateItemHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<ItemCreateDto> Handle(CreateItemRequest request, CancellationToken cancellationToken)
        {
            if (request.Name != null && request.Detailed != null && request.Status != null)
            {
                var itemModel = _mapper.Map<Item>(request);
                await _itemRepository.CreateItem(itemModel);
                _itemRepository.SaveChanges();
                Log.Information("New Item Successfully Created Id:{id}.",itemModel.Id);
                return _mapper.Map<ItemCreateDto>(itemModel);
            }
            Log.Warning("Request must Required Name:{name} , Detailed:{detailed} , Status:{status}.", request.Name, request.Detailed,request.Status);
            //Log.CloseAndFlush();
            return null;
        }
    }
}
