using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMVVM.ViewModels
{
    public class MessageViewModel : Screen
    {
        public string Message { get; set; }
        private string _msg = "this is a message ";
        public string YourMsg
        {
            get { return Message; } //message show to ui
            set { _msg = value; }
        }
    }
}
