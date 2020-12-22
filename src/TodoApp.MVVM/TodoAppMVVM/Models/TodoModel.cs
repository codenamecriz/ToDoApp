using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMVVM.Models
{
    public class TodoModel
    {
        public int TodoModelId { get; set; } 
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ItemModel> TodoItemModels { get; private set; } = new ObservableCollection<ItemModel>();
    }
}
