using Prism.Commands;
using System;
using System.ComponentModel;

namespace TodoApp.MVVM.EventCommands
{
    public interface IVisibilityCommand : INotifyPropertyChanged
    {
        Action Close { get; set; }
        DelegateCommand CloseCommand { get; }

        event PropertyChangedEventHandler PropertyChanged;
      
        
    }
}