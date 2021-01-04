using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.DTOs.Item;

namespace TodoApp.API.Models
{
    public class ItemReadDto : BaseItemDto
    {
        
        public string Name { get; set; }
        public string Detailed { get; set; }
        public string Status { get; set; }
        public int TodoId { get; set; }
    }
}
