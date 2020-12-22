using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.MVVM.IViewModels
{
    public interface ICreateTodoViewModel
    {
   
        string Description { get; set; }
        int Id { get; set; }
        string ListDescription { get; set; }
        string ListName { get; set; }
        string Name { get; set; }
        int TodoId { get; set; }
    }
}
