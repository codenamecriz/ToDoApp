using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.MVVM.Models;
using TodoAppMVVM.Models;
using TodoAppMVVM.Services;
using TodoAppMVVM.ViewModels;

namespace TodoApp.MVVM.EventCommands
{
    public class VisibilityCommand :  IVisibilityCommand
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

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
        //=================================================== Item DataGrid View
        //private ObservableCollection<ItemModel> _itemModel;
        //public ObservableCollection<ItemModel> ItemsDataGrid
        //{
            
        //    get { return _itemModel; }
        //    set
        //    {
        //        if (_itemModel == value) return;
                
        //        _itemModel = value;
                
        //        OnPropertyChanged(nameof(ItemsDataGrid));
        //    }
        //}
        //================================================== List DataGridView
        //private ObservableCollection<TodoModel> _oldListDataGrid ;
        //public ObservableCollection<TodoModel> _listDataGrid;

        //public ObservableCollection<TodoModel> ListDataGrid
        //{

        //    get {

        //        //Console.WriteLine(_listDataGrid.Count); 
        //        return _listDataGrid; 

        //    }
        //    set
        //    {
               
        //        if (_listDataGrid != value)
        //        {
        //            //Refresh = new ObservableCollection<TodoModel>();
        //            //ListDataGrid.Remove(_oldListDataGrid);
                   
        //            _listDataGrid = value;
        //            //if (_oldListDataGrid != null)
        //            //{ _listDataGrid.Clear(); }
        //            //_oldListDataGrid = _listDataGrid;
        //            //_oldListDataGrid = _listDataGrid;

        //            OnPropertyChanged(nameof(ListDataGrid));
                    

        //        }
        //        else { return; }
        //    }
        //}
        //public  void ClearTodoDatagrid()
        //{

        //    if (_listDataGrid != null)
        //    {
        //        Console.WriteLine(_listDataGrid.Count);
        //        Console.WriteLine(ListDataGrid.Count);
        //        ListDataGrid.Clear();
        //        _listDataGrid.Clear();

        //    }
        //}

        //----------------------------------------------------------> Get All List from database
        private ObservableCollection<TodoListDTO> todoListGrid;
        public ObservableCollection<TodoListDTO> TodoListGrid
        {
            get { return todoListGrid; }
            set { todoListGrid = value; OnPropertyChanged("TodoListGrid"); }
        }
        //----------------------------------------------------------> Get All Item from database
        private ObservableCollection<ItemDTO> itemsGrid;
        public ObservableCollection<ItemDTO> ItemsGrid
        {
            get { return itemsGrid; }
            set { itemsGrid = value; OnPropertyChanged("ItemsGrid"); }
        }

        
        //============================================== Close Windows
        private DelegateCommand _closeCommand;
        public DelegateCommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));
        void CloseWindow()
        {
            Close?.Invoke();
        }
        public Action Close { get; set; }
        //-------------=================================== Visibility
        // -->>Link for Tutorial Visibility Property https://www.technical-recipes.com/2016/binding-the-visibility-of-wpf-elements-to-a-property/

        private bool VisibilityProp1;
        public bool Btn_CreateListVisibility
        {
            get { return VisibilityProp1; }
             set
            {
                VisibilityProp1 =  value;
                OnPropertyChanged("Btn_CreateListVisibility");
            }
            
        }
        //=-----------------------------------> Hide/Show Button Create Item
        private bool ItemVisibility;
        public bool Btn_CreateItemVisibility
        {
            get { return ItemVisibility; }
            set
            {
                ItemVisibility = value;
                OnPropertyChanged("Btn_CreateItemVisibility");
            }

        }
        private bool backToListVisibility;
        public bool Btn_BacktoListViewVisibility
        {
            get { return backToListVisibility; }
            set
            {
                backToListVisibility = value;
                OnPropertyChanged("Btn_BacktoListViewVisibility");
            }

        }
        
        //  ------------------------------------> Hide List/Todo DataGridview

        private bool listDataGridViewVisibility;
        public bool ListDataGridViewVisibility
        {
            get { return listDataGridViewVisibility; }
            set
            {
                listDataGridViewVisibility = value;
                OnPropertyChanged("ListDataGridViewVisibility");
            }
         
        }
        //  ------------------------------------> Hide Item DataGridview
        private bool itemDataGridViewVisibility;
        public bool ItemDataGridViewVisibility
        {
            get { return itemDataGridViewVisibility; }
            set
            {
                itemDataGridViewVisibility = value;
                OnPropertyChanged("ItemDataGridViewVisibility");
            }

        }

        
        //private ObservableCollection<ItemModel> _itemModel;

        //public ObservableCollection<ItemModel> Lecturers
        //{
        //    get { return _itemModel; }
        //    set
        //    {
        //        _itemModel = value;
        //        this.OnPropertyChanged("Lecturers");
        //    }
        //}
    }
    
}
