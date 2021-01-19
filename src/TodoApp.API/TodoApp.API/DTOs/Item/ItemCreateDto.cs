using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Enum;

namespace TodoApp.API.DTOs
{
    public class ItemCreateDto
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public EnumItemStatus Status { get; set; }
        public int TodoId { get; set; }
    }
}
