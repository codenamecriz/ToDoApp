using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.DTOs;
using TodoApp.API.Enum;
using static TodoApp.API.Enum.EnumItemStatus;

namespace TodoApp.API.Models
{
   
    public class Item
    {
       
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public EnumItemStatus Status { get; set; }
        [Required]
        public int TodoId { get; set; }

        public virtual Todo TodoModel { get; set; }
    }
}
