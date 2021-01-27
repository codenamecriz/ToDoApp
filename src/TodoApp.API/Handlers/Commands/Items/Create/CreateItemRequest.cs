using MediatR;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Enum;
using TodoApp.API.Models;
using static TodoApp.API.Enum.EnumItemStatus;

namespace Handlers.Commands
{
    public class CreateItemRequest : IRequest<ItemCreateDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public EnumItemStatus Status { get; set; }
        public int TodoId { get; set; }
    }
}
