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
using Services.Commands.Items;
using Services.Queries.Items;

namespace Handlers.Commands
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemRequest, ItemDeleteDto>
    {
        private readonly IItemCommandService _itemCommandService;
        private readonly IItemQueryService _itemQueryService;
        private readonly IMapper _mapper;

        public DeleteItemHandler(IItemCommandService itemCommandService, IMapper mapper, IItemQueryService itemQueryService)
        {
            _itemCommandService = itemCommandService;
            _mapper = mapper;
            _itemQueryService = itemQueryService;
        }
        public async Task<ItemDeleteDto> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
        {
            var itemFromRepo = await _itemQueryService.GetItemByIdAsync(request.Id);
            if (itemFromRepo != null)
            {

                await _itemCommandService.DeleteItemAsync(itemFromRepo);
        
                var result = new ItemDeleteDto { Id = request.Id };
                Log.Information("Item Id:{id} has Successfully Deleted.", request.Id);
                return result;
            }
            Log.Warning("The Request Item Id:{id} To Delete Not Found.", request.Id);
            return null; ;
        }
    }
}
