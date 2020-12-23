using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMVVM.Views;
using Caliburn.Micro;
using TodoAppMVVM.SQLite;
using TodoAppMVVM.Models;
using TodoAppMVVM.Queries;
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
            //INinjectConfiguration _DI, 
            ICreateItemViewModel _createItemViewModel,
            ICreateTodoViewModel _createTodoViewModel)//IDBContext createDb
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
            //Todo Button
            EditCommand = new DelegateCommand<TodoListDTO>(ExecuteEditCommand);
            ViewCommand = new DelegateCommand<TodoListDTO>(ExecuteViewCommand);
            DeleteCommand = new DelegateCommand<TodoListDTO>(ExecuteDeleteCommand);
            //Item Buttons
            EditItemCommand = new DelegateCommand<ItemDTO>(ExecuteEditItemCommand);
            DeleteItemCommand = new DelegateCommand<ItemDTO>(ExecuteDeleteItemCommand);
            BackViewListCommand = new DelegateCommand(ExecuteBackViewListCommand);


        }
        private void Show()
        {
            TodoListGrid = new ObservableCollection<TodoListDTO>(unitofWork.QeuriesServices.GetAll());
            ItemsGrid = new ObservableCollection<ItemDTO>(unitofWork.QeuriesServices.GetItemById(ListId));

        }

        private int ListId;

        //================== button Using ICommand
        private ICommand _createItemCommand, _createTodoCommand;
        public ICommand CreateItemCommand // sample declare a button using ICommand 
        {
            get
            {
                if (_createItemCommand == null)
                {
                    _createItemCommand = new RelayCommand(() =>
                    {
                        createItemViewModel.TodoId = ListId;
                        createItemViewModel.Name = "";
                        createItemViewModel.Detailed = "";
                        //appVM.TodoId = ListId;
                        CreateItemView todoview = new CreateItemView();
                        todoview.DataContext = createItemViewModel;//appVM;
                        todoview.ShowDialog();
                        Show();
                    });
                }

                return _createItemCommand;
            }
        }

        //private ICommand _createTodoCommand;
        public ICommand CreateTodoCommand
        {
            get
            {
                if (_createTodoCommand == null)
                {
                    _createTodoCommand = new RelayCommand(() =>
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
                return _createTodoCommand;
            }
        }
        // This Button Command using DelegateCommand install (Prism)
        //========================================================= back to LIST View  (Deaclearing a Button using DeleGateCommand)

        void ExecuteBackViewListCommand()
        {
            ListDataGridViewVisibility = true; // ListGridView
            ItemDataGridViewVisibility = false; // ItemGridView

            Btn_CreateListVisibility = true;
            Btn_CreateItemVisibility = false;
            Btn_BacktoListViewVisibility = false;
        }
        //============================================================ Delete Todo Button 
     
        void ExecuteDeleteCommand(TodoListDTO parameter)
        {
            var todoParameter = new Todo
            {
                Id = parameter.Id,
                Name = parameter.Name,
                Description = parameter.Description
            };
            var result = unitofWork.catchResult(unitofWork.TodoServices.RemoveList(todoParameter));
            MessageBox.Show(result);
            Show();
            //parameter.TodoModelId
            //https://www.youtube.com/watch?v=IRE2PAD1kIM
        }
        //============================================================ Delete ITEM Button DeleteItemCommand
 
        void ExecuteDeleteItemCommand(ItemDTO parameter)
        {
            var itemParameter = new Item {
                Id = parameter.Id,
                Name = parameter.Name,
                Detailed = parameter.Detailed,
                Status = parameter.Status,

            };
            var result = unitofWork.catchResult(unitofWork.ItemServices.RemoveItem(itemParameter));
            MessageBox.Show(result);
            Show();
        }
        //========================================================== Edit Commnad 

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
        //========================================================== Edit ITem
    
        void ExecuteEditItemCommand(ItemDTO parameter)
        {

            //var appVM = ninjectConfiguration.Configure().Get<CreateItemViewModel>();
     
            createItemViewModel.Id = parameter.Id;
            createItemViewModel.Name = parameter.Name;
            createItemViewModel.Detailed = parameter.Detailed;
            createItemViewModel.Status = parameter.Status;

            CreateItemView itemoview = new CreateItemView();
            itemoview.DataContext = createItemViewModel;//appVM;
            itemoview.ShowDialog();

            Show();
        }
        //========================================================== View Item Commnad
        void ExecuteViewCommand(TodoListDTO parameter)
        {
            ListId = parameter.Id;
            Show();
            ListDataGridViewVisibility = false;
            ItemDataGridViewVisibility = true;
            Btn_CreateListVisibility = false;
            Btn_CreateItemVisibility = true;
            Btn_BacktoListViewVisibility = true;
            //MessageBox.Show(itemsDataGrid..ToString());

        }
        
       

    }

}
