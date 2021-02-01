using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TodoApp.API.Enum;

namespace Services.Commands.Items
{
    public class CreateItemCommand 
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public EnumItemStatus Status { get; set; }
        [Required]
        public int TodoId { get; set; }
    }
}
