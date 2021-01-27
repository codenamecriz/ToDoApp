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
using TodoApp.API.Models;

namespace Handlers.Commands
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
            //if (request.Name != null && request.Details != null)
            //{                
                var itemModel = _mapper.Map<Item>(request);
                await _itemRepository.CreateItem(itemModel);
                _itemRepository.SaveChanges();
                Log.Information("New Item Successfully Created Id:{id}.",itemModel.Id);
                return _mapper.Map<ItemCreateDto>(itemModel);
            //}
            //Log.Warning("Request must Required Name:{name} , Detailed:{detailed} , Status:{status}.", request.Name, request.Details,request.Status);
            //Log.CloseAndFlush();
            //return null;
        }
    }
}
