using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.MVVM.Models;

namespace TodoApp.MVVM.EventCommands
{
    public class ButtonClickCommand
    {
        //============================================== Close Windows
        private DelegateCommand _closeCommand;
        public DelegateCommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));
        void CloseWindow()
        {
            Close?.Invoke();
        }
        public Action Close { get; set; }
        //================================================= Edit DelegateCommand
        private DelegateCommand<TodoListDTO> _editcommand;
        public DelegateCommand<TodoListDTO> EditCommand
        {
            get { return _editcommand; }
            set { _editcommand = value; }
        }
        //================================================ View Item DelegateCommand
        private DelegateCommand<TodoListDTO> _viewCommand;
        public DelegateCommand<TodoListDTO> ViewCommand
        {
            get { return _viewCommand; }
            set { _viewCommand = value; }
        }

        //============================================ Edit Item DelegateCommand
        private DelegateCommand<ItemDTO> _editItemCommand;
        public DelegateCommand<ItemDTO> EditItemCommand
        {
            get { return _editItemCommand; }
            set { _editItemCommand = value; }
        }
        //================================================ Delete Item DelegateCommand
        private DelegateCommand<ItemDTO> _deleteItemCommand;
        public DelegateCommand<ItemDTO> DeleteItemCommand
        {
            get { return _deleteItemCommand; }
            set { _deleteItemCommand = value; }
        }

        //================================================ Delete list DelegateCommand
        private DelegateCommand<TodoListDTO> _deleteCommand;
        public DelegateCommand<TodoListDTO> DeleteCommand
        {
            get { return _deleteCommand; }
            set { _deleteCommand = value; }
        }
        //================================================= back to list view button
        private DelegateCommand _backViewListCommand;
        public DelegateCommand BackViewListCommand
        {
            get { return _backViewListCommand; }
            set { _backViewListCommand = value; }
        }
    }
}
