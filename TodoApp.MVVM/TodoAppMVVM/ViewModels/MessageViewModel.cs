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

        private string _msg = "this is a message ";
        public string YourMsg
        {
            get { return _msg; }
            set { _msg = value; }
        }
    }
}
