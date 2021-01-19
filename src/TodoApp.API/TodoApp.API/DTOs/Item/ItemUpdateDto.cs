using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Enum;

namespace TodoApp.API.DTOs.Item
{
    public class ItemUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Details { get; set; }
        public EnumItemStatus Status { get; set; }
        //public int TodoId { get; set; }
    }
}
