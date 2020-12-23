using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMVVM.Models
{
    public class Todo
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Item> TodoItemModels { get; private set; } = new ObservableCollection<Item>();
    }
}
