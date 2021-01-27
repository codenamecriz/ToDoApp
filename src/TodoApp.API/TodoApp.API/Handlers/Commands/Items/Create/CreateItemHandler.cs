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
using TodoApp.API.Models;
using Services.Commands.Items;

namespace Handlers.Commands
{
    public class CreateItemHandler : IRequestHandler<CreateItemRequest, ItemCreateDto>
    {
        private readonly IItemCommandService _itemService;
        private readonly IMapper _mapper;

        public CreateItemHandler(IItemCommandService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }
        public async Task<ItemCreateDto> Handle(CreateItemRequest request, CancellationToken cancellationToken)
        {
            //if (request.Name != null && request.Details != null)
            //{                
                var itemModel = _mapper.Map<Item>(request);
                await _itemService.CreateItemAsync(itemModel);
           
                Log.Information("New Item Successfully Created Id:{id}.",itemModel.Id);
                return _mapper.Map<ItemCreateDto>(itemModel);
            //}
            //Log.Warning("Request must Required Name:{name} , Detailed:{detailed} , Status:{status}.", request.Name, request.Details,request.Status);
            //Log.CloseAndFlush();
            //return null;
        }
    }
}
