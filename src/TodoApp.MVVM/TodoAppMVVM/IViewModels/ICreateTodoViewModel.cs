using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TodoApp.MVVM.IViewModels
{
    public interface ICreateTodoViewModel
    {
        ICommand CreateTodoButton { get; }
        string Description { get; set; }
        int Id { get; set; }
        string ListDescription { get; set; }
        string ListName { get; set; }
        string Name { get; set; }
        int TodoId { get; set; }
    }
}
