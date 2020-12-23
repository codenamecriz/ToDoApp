using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TodoApp.MVVM.IViewModels
{
    public interface ICreateItemViewModel 
    {
        ICommand CreateItemCommand { get; }
        string Detailed { get; set; }
        int Id { get; set; }
        string ItemDetailed { get; set; }
        string ItemName { get; set; }
        string Name { get; set; }
        string SelectStatus { get; set; }
        string Status { get; set; }
        int TodoId { get; set; }
    }
}
