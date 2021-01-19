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
using static TodoApp.API.Enum.EnumItemStatus;

namespace TodoApp.API.Handlers.Queries.Items
{
    public class GetTodoItemsByIdHandler : IRequestHandler<GetTodoItemsByIdRequest, IEnumerable<ItemResponseDto>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetTodoItemsByIdHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ItemResponseDto>> Handle(GetTodoItemsByIdRequest request, CancellationToken cancellationToken)
        {
            //Console.WriteLine(request.Id);
            var itemFromRepo = await _itemRepository.GetTodoItemsById(request.Id);
            Log.Information("Request all Items where TodoId = {id} from Repository.", request.Id);
    
            /*var itemCollection = new List<ItemResponseDto>();
            foreach (var item in itemFromRepo)
            {
                Console.WriteLine("----> "+item.Status);
                var s = "Done";
                if (item.Status == 0)
                { s = "Pending"; }
                itemCollection.Add(new ItemResponseDto
                {
                    Name = item.Name,
                    Detailed = item.Details,
                    Status = s//((ItemS)item.Status).ToString();
                });

            }
            return itemCollection;*/
            Console.WriteLine(itemFromRepo);
            return itemFromRepo != null ? _mapper.Map<IEnumerable<ItemResponseDto>>(itemFromRepo) : null;
          
        }
    }
}
