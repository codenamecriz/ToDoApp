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
                  
            var itemModel = _mapper.Map<CreateItemCommand>(request);
            var result = await _itemService.CreateItemAsync(itemModel);

            if(result.Id != 0)
            {
                Log.Information("New Item Successfully Created Id:{id}.", result.Id);
                var itemDto =  _mapper.Map<ItemCreateDto>(itemModel);
                var itemDto2 = _mapper.Map(result, itemDto);
                return itemDto2;// _mapper.Map<ItemCreateDto>(itemModel);
            }

            return null;

        }
    }
}
