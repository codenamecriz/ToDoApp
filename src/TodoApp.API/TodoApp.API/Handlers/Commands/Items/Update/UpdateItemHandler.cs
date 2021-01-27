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

namespace Handlers.Commands
{
    public class UpdateItemHandler : IRequestHandler<UpdateItemRequest, ItemUpdateDto>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public UpdateItemHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<ItemUpdateDto> Handle(UpdateItemRequest request, CancellationToken cancellationToken)
        {
            var dataFromRepo = await _itemRepository.GetItemById(request.Id);
            if (dataFromRepo != null)
            {
                //Console.WriteLine(request.);
                _mapper.Map(request.ItemToUpdate, dataFromRepo);
                await _itemRepository.UpdateItem(dataFromRepo);
                _itemRepository.SaveChanges();
                var result = _mapper.Map<ItemUpdateDto>(request.ItemToUpdate);
                //var result = new TodoUpdateDto { Name = dataFromRepo.Name, Description = dataFromRepo.Description };
                Log.Information("Request Item Id:{id} Successfully Updated.", request.Id);
                return result;
            }
            Log.Warning("Request Item Id:{id} To Update Not Found.", request.Id);
            return null;
        }
    }
}
