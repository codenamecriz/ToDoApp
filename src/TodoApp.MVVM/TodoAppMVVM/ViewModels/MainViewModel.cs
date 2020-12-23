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
    public class MainViewModel : VisibilityCommand , IMainViewModel//:  INotifyPropertyChanged
    {
        private readonly IBuildConnection _dbConnect;

        private readonly IUnitOfWork unitofWork;
        
        private readonly IDBContext createDb;
        //private readonly IWindowManager manager;//= new WindowManager();
        private readonly INinjectConfiguration DI;
        public MainViewModel(IUnitOfWork _unitofWork, IBuildConnection dbConnect, IDBContext _createDb, INinjectConfiguration _DI)//IDBContext createDb
        {
            createDb = _createDb;
            if (File.Exists("TodoDatabase.db"))
            {  }
            else
            {
                createDb.CreateDb();
            }
            unitofWork = _unitofWork;

            DI = _DI;//new NinjectConfiguration();
     
            _dbConnect = dbConnect;
            
            Btn_CreateListVisibility = true;
            ListDataGridViewVisibility = true;
            ItemDataGridViewVisibility = false;

            Show();
            //LoadData();

        }
        private void Show()
        {
            TodoListGrid = new ObservableCollection<TodoListDTO>(unitofWork.QeuriesServices.GetAll());
            ItemsGrid = new ObservableCollection<ItemDTO>(unitofWork.QeuriesServices.GetItemById(ListId));
         
        }
      
        private int ListId; 

        //public void Btn_CreateItem()
        //{
        //    CreateItemViewModel ItemWindow = new CreateItemViewModel();
        //    ItemWindow.TodoId = ListId;
        //    manager.ShowDialog(ItemWindow);
        //    Show();
        //}

        private ICommand _createItemCommand;

        public ICommand CreateItemCommand // sample declare a button using ICommand 
        {
            get
            {
                if (_createItemCommand == null)
                {
                    _createItemCommand = new RelayCommand(() =>
                    {
                       
                        var appVM = DI.Configure().Get<CreateItemViewModel>();
                       
                        appVM.TodoId = ListId;
                        CreateItemView todoview = new CreateItemView();
                        todoview.DataContext = appVM;
                        todoview.ShowDialog();
                        Show();
                    });
                }

                return _createItemCommand;
            }
        }

        private ICommand _createTodoCommand;

        public ICommand CreateTodoCommand
        {
            get
            {
                if (_createTodoCommand == null)
                {
                    _createTodoCommand = new RelayCommand(() =>
                    {
                        var appVM = DI.Configure().Get<CreateTodoViewModel>();
                        CreateTodoView todoview = new CreateTodoView();
                        todoview.DataContext = appVM;
                        todoview.ShowDialog();
                        //manager.ShowDialog(todoview);
                        Show();
                        
                    });
                }
                
                return _createTodoCommand;
            }
        }

        //========================================================= back to LIST View  (Deaclearing a Button using DeleGateCommand)
        private DelegateCommand _backViewListCommand;
        public DelegateCommand BackViewListCommand =>
                    _backViewListCommand ?? (_backViewListCommand = new DelegateCommand(ExecuteBackViewListCommand));
        void ExecuteBackViewListCommand()
        {
            ListDataGridViewVisibility = true; // ListGridView
            ItemDataGridViewVisibility = false; // ItemGridView

            Btn_CreateListVisibility = true;
            Btn_CreateItemVisibility = false;
            Btn_BacktoListViewVisibility = false;
        }
        //============================================================ Delete Todo Button 
        private DelegateCommand<TodoListDTO> _deleteCommand;
        public DelegateCommand<TodoListDTO> DeleteCommand =>
                    _deleteCommand ?? (_deleteCommand = new DelegateCommand<TodoListDTO> (ExecuteDeleteCommand));
        void ExecuteDeleteCommand(TodoListDTO parameter)
        {
            //MessageViewModel msg = new MessageViewModel();
            //msg.Message = parameter.TodoModelId.ToString();

            //manager.ShowWindow(msg);
            //var todoParameter = new List<TodoModel>();
            var todoParameter = new Todo
            {
                Id = parameter.Id,
                Name = parameter.Name,
                Description = parameter.Description
            };
            var result = unitofWork.catchResult(unitofWork.TodoServices.RemoveList(todoParameter));
            MessageBox.Show(result);
            //ListDataGrid.Remove(parameter);
            Show();
            //parameter.TodoModelId
            //https://www.youtube.com/watch?v=IRE2PAD1kIM
        }
        //============================================================ Delete ITEM Button DeleteItemCommand
        private DelegateCommand<ItemDTO> _deleteItemCommand;
        public DelegateCommand<ItemDTO> DeleteItemCommand =>
                    _deleteItemCommand ?? (_deleteItemCommand = new DelegateCommand<ItemDTO>(ExecuteDeleteItemCommand));
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
            //ItemsDataGrid.Remove(parameter);
            Show();
        }
        //========================================================== Edit Commnad 
        private DelegateCommand<TodoListDTO> _editCommand;
        public DelegateCommand<TodoListDTO> EditCommand =>
                    _editCommand ?? (_editCommand = new DelegateCommand<TodoListDTO>(ExecuteEditCommand));
        void ExecuteEditCommand(TodoListDTO parameter)
        {

            var appVM = DI.Configure().Get<CreateTodoViewModel>();
            CreateTodoView todoview = new CreateTodoView();
            appVM.Id = parameter.Id;
            appVM.Name = parameter.Name;
            appVM.Description = parameter.Description;
            todoview.DataContext = appVM;
            todoview.ShowDialog();

            //IKernel kernel = new StandardKernel();
            //var appVM = kernel.Get<CreateTodoViewModel>();

            //CreateTodoView todoview = new CreateTodoView();
            //appVM.Id = parameter.TodoId;
            //appVM.Name = parameter.Name;
            //appVM.Description = parameter.Description;
            //todoview.DataContext = appVM;

            //todoview.ShowDialog();

            Show();
        }
        //========================================================== Edit ITem
        private DelegateCommand<ItemDTO> _editItemCommand;
        public DelegateCommand<ItemDTO> EditItemCommand =>
                    _editItemCommand ?? (_editItemCommand = new DelegateCommand<ItemDTO>(ExecuteEditItemCommand));
        void ExecuteEditItemCommand(ItemDTO parameter)
        {

            var appVM = DI.Configure().Get<CreateItemViewModel>();
            CreateItemView itemoview = new CreateItemView();
            appVM.Id = parameter.Id;
            appVM.Name = parameter.Name;
            appVM.Detailed = parameter.Detailed;
            appVM.Status = parameter.Status;
            itemoview.DataContext = appVM;
            itemoview.ShowDialog();

            //IKernel kernel = new StandardKernel();
            //var appVM = kernel.Get<CreateItemViewModel>();

            //CreateItemView todoview = new CreateItemView();
            //appVM.Id = parameter.ItemId;
            //appVM.Name = parameter.Name;
            //appVM.Detailed = parameter.Detailed;
            //appVM.Status = parameter.Status;
            //todoview.DataContext = appVM;

            //todoview.ShowDialog();

            Show();
        }
        //========================================================== View Item Commnad
        private DelegateCommand<TodoListDTO> _viewCommand;
        public DelegateCommand<TodoListDTO> ViewCommand =>
                    _viewCommand ?? (_viewCommand = new DelegateCommand<TodoListDTO>(ExecuteViewCommand));
         
        void ExecuteViewCommand(TodoListDTO parameter)
        {
           
            ListId = parameter.Id;
            //MessageViewModel msg = new MessageViewModel();
            //msg.Message = parameter.TodoModelId.ToString();

            //manager.ShowWindow(msg);

            //var b = unitofWork.ItemServices.LoadItem(parameter.TodoModelId);
            //foreach (ItemModel a in b)
            //{
            //    MessageBox.Show(a.ItemModelId + "");
            //}

            Show();
            ListDataGridViewVisibility = false;
            ItemDataGridViewVisibility = true;
            Btn_CreateListVisibility = false;
            Btn_CreateItemVisibility = true;
            Btn_BacktoListViewVisibility = true;
            //MessageBox.Show(itemsDataGrid..ToString());

        }
        
        //public BindableCollection<ItemModel> _itemModel;
        //public BindableCollection<ItemModel> ItemsDataGrid
        //{
        //    get
        //    {
        //        return new BindableCollection<string>(Model.FoldersToScan);
        //    }
        //    set
        //    {
        //        Model.FoldersToScan = value;
        //        NotifyOfPropertyChange(() => FoldersToScan);
        //    }
        //}
        //public BindableCollection<ItemModel> ItemsDataGrid
        //{
        //    get
        //    {
        //        if (Name == null)
        //        { Name = ""; }
        //        return Name;
        //    }
        //    set { Name = value; }
        //}
        //private ObservableCollection<ItemModel> lecturers;

        //public ObservableCollection<Lecturer> Lecturers
        //{
        //    get { return lecturers; }
        //    set
        //    {
        //        lecturers = value;
        //        this.NotifyPropertyChanged("Lecturers");
        //    }
        //}

    }

}
