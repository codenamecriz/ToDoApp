using MediatR;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace Handlers.Queries
{
    public class GetItemByIdRequest : IRequest<ItemResponseDto>
    {
        public int Id { get; }

        public GetItemByIdRequest(int id)
        {
            Id = id;
        }
    }
}
