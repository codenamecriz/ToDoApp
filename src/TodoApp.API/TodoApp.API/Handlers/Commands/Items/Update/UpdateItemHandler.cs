using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.API.Data;
using TodoApp.API.DTOs.Item;

namespace TodoApp.API.Handlers.Commands.Items.Update
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
                return result;
            }
            return null;
        }
    }
}
