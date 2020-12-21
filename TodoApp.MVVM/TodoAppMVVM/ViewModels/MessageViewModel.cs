using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.MVVM.IViewModels;

namespace TodoAppMVVM.ViewModels
{
    public class MessageViewModel : IMessageViewModel
    {
        public string Message { get; set; }

        public MessageViewModel()
        {
            Console.WriteLine("-"+Message);
        }
      
        public string YourMsg
        {
            get { return Message; } //message show to ui
            set { Message = value; }
        }
    }
}
