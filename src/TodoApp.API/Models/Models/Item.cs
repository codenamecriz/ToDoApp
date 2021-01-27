using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.DTOs;
using TodoApp.API.Enum;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.API.Models
{
   
    public class Item
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public EnumItemStatus Status { get; set; }
        [Required]
        public int TodoId { get; set; }

        public virtual Todo Todos { get; set; }

        //public Item(string name, string details, EnumItemStatus status, int todoId, Todo todos)
        //{
        //    Name = name;
        //    Details = details;
        //    Status = status;
        //    TodoId = todoId;
        //    Todos = todos;
        //}

        //public int Id { get; set; }

        //public string Name { get; }

        //public string Details { get; }

        //public EnumItemStatus Status { get; }

        //public int TodoId { get; }

        //public virtual Todo Todos { get; }
    }
}
