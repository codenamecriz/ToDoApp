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
    public class GetTodoItemsByIdHandler : IRequestHandler<GetTodoItemsByIdRequest, IEnumerable<ItemReadDto>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetTodoItemsByIdHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ItemReadDto>> Handle(GetTodoItemsByIdRequest request, CancellationToken cancellationToken)
        {
            //Console.WriteLine(request.Id);
            var itemFromRepo = await _itemRepository.GetTodoItemsById(request.Id);
            //Console.WriteLine(itemFromRepo != null);
            return itemFromRepo != null ? _mapper.Map<IEnumerable<ItemReadDto>>(itemFromRepo) : null;
            //return _mapper.Map<IEnumerable<ItemReadDto>>(itemsFromRepo);
        }
    }
}
