using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.MVVM.EventCommands;
using TodoApp.MVVM.Models;

namespace TodoApp.MVVM.IViewModels
{
    public interface IMainViewModel 
    {
        DelegateCommand<TodoListDTO> DeleteCommand { get; }
        DelegateCommand<ItemDTO> DeleteItemCommand { get; }
        DelegateCommand<TodoListDTO> EditCommand { get; }
        DelegateCommand<ItemDTO> EditItemCommand { get; }
        DelegateCommand<TodoListDTO> ViewCommand { get; }

        //void btn_BacktoListView();
        //void Btn_CreateItem();
        //void Btn_CreateList();
    }
}
