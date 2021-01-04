using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMVVM.Views;
using Caliburn.Micro;
using TodoAppMVVM.SQLite;
using TodoAppMVVM.Models;
using System.IO;
using TodoAppMVVM.Services;
using System.Windows;
using Prism.Commands;
using System.ComponentModel;
using Hangfire.Annotations;
using System.Runtime.CompilerServices;
using TodoApp.MVVM.EventCommands;
using System.Collections.ObjectModel;
using TodoApp.MVVM.Models;
using TodoApp.MVVM.IViewModels;
using Ninject;
using System.Windows.Input;
using TodoApp.MVVM.Commands;
using TodoApp.MVVM.Services;
using TodoApp.MVVM;

namespace TodoAppMVVM.ViewModels
{
    public class MainViewModel : VisibilityCommand, IMainViewModel
    {
        private readonly IUnitOfWork _unitofWork;

        private readonly IDBContext _dbContext;
        private readonly ICreateItemViewModel _createItemViewModel;
        private readonly ICreateTodoViewModel _createTodoViewModel;
        private int ListId;
        public MainViewModel(IUnitOfWork unitofWork,
            IDBContext dbContext, 
            ICreateItemViewModel createItemViewModel,
            ICreateTodoViewModel createTodoViewModel)
        {
            _dbContext = dbContext;
            if (File.Exists("TodoDatabase.db"))
            { }
            else
            {
                _dbContext.CreateDb();
            }

            _createItemViewModel = createItemViewModel;
            _createTodoViewModel = createTodoViewModel;
            _unitofWork = unitofWork;
            Btn_CreateListVisibility = true;
            ListDataGridViewVisibility = true;
            ItemDataGridViewVisibility = false;

            Show();
            #region Todo Buttons
            EditCommand = new DelegateCommand<TodoListDTO>(ExecuteEditCommand);
            ViewCommand = new DelegateCommand<TodoListDTO>(ExecuteViewCommand);
            DeleteCommand = new DelegateCommand<TodoListDTO>(ExecuteDeleteCommand);
            #endregion

            #region Item Buttons
            EditItemCommand = new DelegateCommand<ItemDTO>(ExecuteEditItemCommand);
            DeleteItemCommand = new DelegateCommand<ItemDTO>(ExecuteDeleteItemCommand);
            BackViewListCommand = new DelegateCommand(ExecuteBackViewListCommand);
            #endregion

        }
        #region Show() Load Data Collection
        private void Show()
        {
            TodoListGrid = new ObservableCollection<TodoListDTO>(_unitofWork.QeuriesServices.GetAll());
            ItemsGrid = new ObservableCollection<ItemDTO>(_unitofWork.QeuriesServices.GetItemById(ListId));

        }
        #endregion

        

        //button Using ICommand
        #region Create Item Button
        public ICommand CreateItemButton 
        {
            get
            {
                if (_createItemButton == null)
                {
                    _createItemButton = new RelayCommand(() =>
                    {
                        _createItemViewModel.TodoId = ListId;
                        _createItemViewModel.Name = "";
                        _createItemViewModel.Detailed = "";
                        CreateItemView todoview = new CreateItemView();
                        todoview.DataContext = _createItemViewModel;
                        todoview.ShowDialog();
                        Show(); // load data
                    });
                }
                return _createItemButton;
            }
        }
        #endregion

        #region Create Todo Button
        public ICommand CreateTodoButton
        {
            get
            {
                if (_createTodoButton == null)
                {
                    _createTodoButton = new RelayCommand(() =>
                    {
                        CreateTodoView todoview = new CreateTodoView();
                        _createTodoViewModel.Id = 0;
                        _createTodoViewModel.Name = "";
                        _createTodoViewModel.Description = "";
                        todoview.DataContext = _createTodoViewModel;
                        todoview.ShowDialog();
                        Show();

                    });
                }
                return _createTodoButton;
            }
        }
        #endregion


        // Button using DelegateCommand -> install (Prism)
        
        #region Back to Todo View Button
        void ExecuteBackViewListCommand()
        {
            ListDataGridViewVisibility = true; 
            ItemDataGridViewVisibility = false; 

            Btn_CreateListVisibility = true;
            Btn_CreateItemVisibility = false;
            Btn_BacktoListViewVisibility = false;
        }
        #endregion
       
        #region Todo Delete Button
        void ExecuteDeleteCommand(TodoListDTO parameter)
        {
            var todoParameter = new Todo
            {
                Id = parameter.Id,
                Name = parameter.Name,
                Description = parameter.Description
            };
            var result = _unitofWork.CatchResult(_unitofWork.TodoServices.RemoveList(todoParameter));
            MessageBox.Show(result);
            Show();
            //https://www.youtube.com/watch?v=IRE2PAD1kIM
        }
        #endregion

        #region Item Delete Button
        void ExecuteDeleteItemCommand(ItemDTO parameter)
        {
            var itemParameter = new Item {
                Id = parameter.Id,
                Name = parameter.Name,
                Detailed = parameter.Detailed,
                Status = parameter.Status,

            };
            var result = _unitofWork.CatchResult(_unitofWork.ItemServices.RemoveItem(itemParameter));
            MessageBox.Show(result);
            Show();
        }
        #endregion

        #region Todo Update Button
        void ExecuteEditCommand(TodoListDTO parameter)
        {

            _createTodoViewModel.Id = parameter.Id;
            _createTodoViewModel.Name = parameter.Name;
            _createTodoViewModel.Description = parameter.Description;

            CreateTodoView todoview = new CreateTodoView();
            todoview.DataContext = _createTodoViewModel;
            todoview.ShowDialog();

            Show();
        }
        #endregion

        #region Item Update Button
        void ExecuteEditItemCommand(ItemDTO parameter)
        {

            _createItemViewModel.Id = parameter.Id;
            _createItemViewModel.Name = parameter.Name;
            _createItemViewModel.Detailed = parameter.Detailed;
            _createItemViewModel.Status = parameter.Status;

            CreateItemView itemoview = new CreateItemView();
            itemoview.DataContext = _createItemViewModel;
            itemoview.ShowDialog();
            _createItemViewModel.Id = 0;

            Show();
        }
        #endregion

        #region View Item Button
        void ExecuteViewCommand(TodoListDTO parameter)
        {
            ListId = parameter.Id;
            Show();
            ListDataGridViewVisibility = false;
            ItemDataGridViewVisibility = true;
            Btn_CreateListVisibility = false;
            Btn_CreateItemVisibility = true;
            Btn_BacktoListViewVisibility = true;
            
        }
        #endregion
    }

}
