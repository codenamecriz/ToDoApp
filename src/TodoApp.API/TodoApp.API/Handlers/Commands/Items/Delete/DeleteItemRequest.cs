using MediatR;
using Models.DTOs;
using Services.Commands.Items.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Handlers.Commands
{
    public class DeleteItemRequest : DeleteItemCommand , IRequest<ItemDeleteDto>
    {
        public DeleteItemRequest(int id)
        {
            Id = id;
        }
        //public int Id { get; set; }
        //public DeleteItemRequest(int id)
        //{
        //    Id = id;
        //}
    }
}
