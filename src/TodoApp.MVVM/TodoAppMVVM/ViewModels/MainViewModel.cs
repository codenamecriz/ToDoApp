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
    public class MainViewModel : VisibilityCommand, IMainViewModel//:  INotifyPropertyChanged
    {
        private readonly IUnitOfWork unitofWork;

        private readonly IDBContext dbContext;
        private readonly ICreateItemViewModel createItemViewModel;
        private readonly ICreateTodoViewModel createTodoViewModel;
        public MainViewModel(IUnitOfWork _unitofWork,
            IDBContext _dbContext, 
            ICreateItemViewModel _createItemViewModel,
            ICreateTodoViewModel _createTodoViewModel)
        {
            dbContext = _dbContext;
            if (File.Exists("TodoDatabase.db"))
            { }
            else
            {
                dbContext.CreateDb();
            }

            createItemViewModel = _createItemViewModel;
            createTodoViewModel = _createTodoViewModel;
            unitofWork = _unitofWork;
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
            TodoListGrid = new ObservableCollection<TodoListDTO>(unitofWork.QeuriesServices.GetAll());
            ItemsGrid = new ObservableCollection<ItemDTO>(unitofWork.QeuriesServices.GetItemById(ListId));

        }
        #endregion

        private int ListId;

        //button Using ICommand
        #region Create Item Button
        public ICommand CreateItemButton // sample declare a button using ICommand 
        {
            get
            {
                if (_createItemButton == null)
                {
                    _createItemButton = new RelayCommand(() =>
                    {
                        createItemViewModel.TodoId = ListId;
                        createItemViewModel.Name = "";
                        createItemViewModel.Detailed = "";
                        //appVM.TodoId = ListId;
                        CreateItemView todoview = new CreateItemView();
                        todoview.DataContext = createItemViewModel;//appVM;
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
                        createTodoViewModel.Id = 0;
                        createTodoViewModel.Name = "";
                        createTodoViewModel.Description = "";
                        todoview.DataContext = createTodoViewModel;//appVM;
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
            var result = unitofWork.CatchResult(unitofWork.TodoServices.RemoveList(todoParameter));
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
            var result = unitofWork.CatchResult(unitofWork.ItemServices.RemoveItem(itemParameter));
            MessageBox.Show(result);
            Show();
        }
        #endregion

        #region Todo Update Button
        void ExecuteEditCommand(TodoListDTO parameter)
        {

            createTodoViewModel.Id = parameter.Id;
            createTodoViewModel.Name = parameter.Name;
            createTodoViewModel.Description = parameter.Description;

            CreateTodoView todoview = new CreateTodoView();
            todoview.DataContext = createTodoViewModel;//appVM;
            todoview.ShowDialog();

            Show();
        }
        #endregion

        #region Item Update Button
        void ExecuteEditItemCommand(ItemDTO parameter)
        {

            createItemViewModel.Id = parameter.Id;
            createItemViewModel.Name = parameter.Name;
            createItemViewModel.Detailed = parameter.Detailed;
            createItemViewModel.Status = parameter.Status;

            CreateItemView itemoview = new CreateItemView();
            itemoview.DataContext = createItemViewModel;//appVM;
            itemoview.ShowDialog();
            createItemViewModel.Id = 0;

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
