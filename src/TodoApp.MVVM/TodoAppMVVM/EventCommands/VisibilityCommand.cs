using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.MVVM.Models;
using TodoAppMVVM.Models;
using TodoAppMVVM.Services;
using TodoAppMVVM.ViewModels;

namespace TodoApp.MVVM.EventCommands
{
    public class VisibilityCommand : ButtonClickCommand,  IVisibilityCommand
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public ICommand _createItemButton,
                      _createTodoButton;

        #region OnPropertyChange
        public void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new ArgumentNullException(GetType().Name + " Does not contain property: " + propertyName);
        }
        #endregion

        #region Get All List From Database

        private ObservableCollection<TodoListDTO> todoListGrid;
        public ObservableCollection<TodoListDTO> TodoListGrid
        {
            get { return todoListGrid; }
            set { todoListGrid = value; OnPropertyChanged("TodoListGrid"); }
        }
        #endregion

        #region Get All Item from Database
  
        private ObservableCollection<ItemDTO> itemsGrid;
        public ObservableCollection<ItemDTO> ItemsGrid
        {
            get { return itemsGrid; }
            set { itemsGrid = value; OnPropertyChanged("ItemsGrid"); }
        }
        #endregion

        private bool _btn_CreateListVisibility,
                      _btn_CreateItemVisibility,
                     _btn_BacktoListViewVisibility,
                     _listDataGridViewVisibility,
                     _itemDataGridViewVisibility;

        #region Visibility of Create List & Item Button
        // -->>Link for Tutorial Visibility Property https://www.technical-recipes.com/2016/binding-the-visibility-of-wpf-elements-to-a-property/
        public bool Btn_CreateListVisibility
        {
            get { return _btn_CreateListVisibility; }
             set
            {
                _btn_CreateListVisibility =  value;
                OnPropertyChanged("Btn_CreateListVisibility");
            }
            
        }
        // Hide/Show Button Create Item
        public bool Btn_CreateItemVisibility
        {
            get { return _btn_CreateItemVisibility; }
            set
            {
                _btn_CreateItemVisibility = value;
                OnPropertyChanged("Btn_CreateItemVisibility");
            }
        }
        #endregion

        #region Visibility Back to Todo DataGrid
        public bool Btn_BacktoListViewVisibility
        {
            get { return _btn_BacktoListViewVisibility; }
            set
            {
                _btn_BacktoListViewVisibility = value;
                OnPropertyChanged("Btn_BacktoListViewVisibility");
            }
        }
        #endregion

        #region Visibility List/Item DataGridView

        public bool ListDataGridViewVisibility
        {
            get { return _listDataGridViewVisibility; }
            set
            {
                _listDataGridViewVisibility = value;
                OnPropertyChanged("ListDataGridViewVisibility");
            }
         
        }
        //  Hide Item DataGridview
        public bool ItemDataGridViewVisibility
        {
            get { return _itemDataGridViewVisibility; }
            set
            {
                _itemDataGridViewVisibility = value;
                OnPropertyChanged("ItemDataGridViewVisibility");
            }
        }
        #endregion

       
    }

}
