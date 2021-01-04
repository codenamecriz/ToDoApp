using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.API.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual ICollection<Item> TodoItemModels { get; private set; } = new ObservableCollection<Item>();
    }
}
