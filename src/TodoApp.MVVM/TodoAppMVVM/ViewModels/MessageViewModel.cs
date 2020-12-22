using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.MVVM.Commands;
using TodoApp.MVVM.EventCommands;
using TodoApp.MVVM.IViewModels;

namespace TodoAppMVVM.ViewModels
{
    public class MessageViewModel : VisibilityCommand,IMessageViewModel
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
        //private ICommand _msgCloseCommand;

        //public ICommand MsgCloseCommand
        //{
        //    get
        //    {
        //        if (_msgCloseCommand == null)
        //        {
        //            _msgCloseCommand = new RelayCommand(() =>
        //            {
        //                //MessageViewModel msg = new MessageViewModel();
        //                Console.WriteLine("here");
        //                Close?.Invoke();
                        
        //            });
        //        }

        //        return _msgCloseCommand;
        //    }
        //}
    }
}
