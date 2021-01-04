using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.API.DTOs
{
    public class TodoCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
