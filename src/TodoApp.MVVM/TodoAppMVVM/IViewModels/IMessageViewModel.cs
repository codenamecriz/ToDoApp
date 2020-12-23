using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.MVVM.IViewModels
{
    public interface IMessageViewModel
    {
        string Message { get; set; }
        string YourMsg { get; set; }
    }
}
