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
        private DelegateCommand _closeCommand, _backViewListCommand;
        private DelegateCommand<TodoListDTO> _editcommand, _viewCommand, _deleteCommand;
        //Close Windows
        public DelegateCommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));
        void CloseWindow()
        {
            Close?.Invoke();
        }
        public Action Close { get; set; }
        
        #region back to list view button
        public DelegateCommand BackViewListCommand
        {
            get { return _backViewListCommand; }
            set { _backViewListCommand = value; }
        }
        #endregion

        #region view Item Using DelegateCommand
        public DelegateCommand<TodoListDTO> ViewCommand
        {
            get { return _viewCommand; }
            set { _viewCommand = value; }
        }
        #endregion

        #region Update Todo/Item using DelegateCommand
        //Edit Todo DelegateCommand
        public DelegateCommand<TodoListDTO> EditCommand
        {
            get { return _editcommand; }
            set { _editcommand = value; }
        }
        // Edit Item DelegateCommand
        private DelegateCommand<ItemDTO> _editItemCommand, _deleteItemCommand;
        public DelegateCommand<ItemDTO> EditItemCommand
        {
            get { return _editItemCommand; }
            set { _editItemCommand = value; }
        }
        #endregion

        #region Delete Todo/Item using DelegateCommand
        // Delete Item DelegateCommand
        public DelegateCommand<ItemDTO> DeleteItemCommand
        {
            get { return _deleteItemCommand; }
            set { _deleteItemCommand = value; }
        }
        // Delete list DelegateCommand
        public DelegateCommand<TodoListDTO> DeleteCommand
        {
            get { return _deleteCommand; }
            set { _deleteCommand = value; }
        }
        #endregion
    }
}
