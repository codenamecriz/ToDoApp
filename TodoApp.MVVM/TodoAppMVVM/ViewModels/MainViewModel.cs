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

namespace TodoAppMVVM.ViewModels
{
    public class MainViewModel : VisibilityCommand//:  INotifyPropertyChanged
    {

       
        public MainViewModel()
        {
            if (File.Exists("TodoDatabase.db"))
            { }
            else
            {
                createDb.CreateDb();
            }
            //ItemQuery = _ItemQuery;
            //TodoQuery = _TodoQuery;
            //unitofWork = _unitofWork;
            //_dbConnect = dbConnect;
            unitofWork = new UnitOfWork();
            _dbConnect = new BuildConnection();
            //DbConnect db = new DbConnect();
            Btn_CreateListVisibility = true;
            ListDataGridViewVisibility = true;
            ItemDataGridViewVisibility = false;
            
            GetList();
            
        }
        
        //========================================================================================================
        IWindowManager manager = new WindowManager();
        //private IObservableCollection<TodoModel> todoModel ;
        public BindableCollection<TodoModel> listDataGrid { get; set; }
        //public BindableCollection<ItemModel> ItemsDataGrid { get; set; }

        //private readonly IBuildConnection _dbConnect;

        //private readonly IUnitOfWork unitofWork;

        private readonly BuildConnection _dbConnect;

        private readonly UnitOfWork unitofWork;

        private readonly DBContext createDb = new DBContext();
        //public MainViewModel()//IBuildConnection dbConnect, IUnitOfWork _unitofWork)//IGetAllTodoQuery _TodoQuery, IGetAllItemQuery _ItemQuery
        //{
        //    if (File.Exists("TodoDatabase.db"))
        //    { }
        //    else
        //    {
        //        createDb.CreateDb();
        //    }
        //    //ItemQuery = _ItemQuery;
        //    //TodoQuery = _TodoQuery;
        //    //unitofWork = _unitofWork;
        //    //_dbConnect = dbConnect;
        //    unitofWork = new UnitOfWork();
        //    _dbConnect = new BuildConnection();
        //    //DbConnect db = new DbConnect();
        //    GetList();
            
        //}
        private void GetList()
        {

            //var container = App.Configure();
            //var _listDbContext = container.Resolve<IDetalistRepository>();
            //var _itemDbContext = container.Resolve<IItemRepository>();
   
            
            listDataGrid = new BindableCollection<TodoModel>(unitofWork.ListServices.LoadList());
            //itemsDataGrid = new BindableCollection<ItemModel>(unitofWork.ItemServices.LoadItem(1));

            //itemsDataGrid.ItemsSource = _itemDbContext.GetAll(ListDataId);
            listDataGrid.Refresh();
            
            // bind to the source

        }
        public void btn_BacktoListView()
        {
            ListDataGridViewVisibility = true; // ListGridView
            ItemDataGridViewVisibility = false; // ItemGridView

            Btn_CreateListVisibility = true; 
            Btn_CreateItemVisibility = false;
            Btn_BacktoListViewVisibility = false;
        }
        public void Btn_CreateList() // Open Windows to Add Item Todo Data
        {

            //CreateTodoView viewCtodo = new CreateTodoView();
            //viewCtodo.ShowDialog();
            //DisplayRootViewFor<CreateTodoViewModel>();

            //Bootstrapper _container = new Bootstrapper();

            //var TodoWindow = _container.GetInstance(CreateTodoViewModel, CreateTodoViewModel);
            //var updateDataList = new TodoModel
            //{
            //    TodoModelId = 1,
            //    Name = "passname",
            //    Description = ""
            //};
            //----------
            //DisplayRootViewFor<MainViewModel>();
            //Btn_CreateListVisibility = Visibility.Hidden; //show it
           
            CreateTodoViewModel TodoWindow = new CreateTodoViewModel();

            manager.ShowDialog(TodoWindow);
            
            //--------
            GetList();
            //manager.ShowWindow(new CreateTodoViewModel(), null, null);

            //MessageView viewCtodo = new MessageView();
            //viewCtodo.ShowDialog();

        }
       
        //private string msg = "this is message";
        //public string Labelmsg
        //{
        //    get { return msg; }
        //    set { msg = value; }
        //}
        
        public void Btn_ViewItem()
        {

            CreateTodoViewModel TodoWindow = new CreateTodoViewModel();

            manager.ShowDialog(TodoWindow);
            //Btn_CreateList.Visibility = Visibility.Hidden;
            //btn_CreateItem.Visibility = Visibility.Visible;
            //btn_BacktoListView.Visibility = Visibility.Visible;

            //listDataGrid.Visibility = Visibility.Hidden;
            //itemsDataGrid.Visibility = Visibility.Visible;
        }

        //============================================================ delete Button
        private DelegateCommand<TodoModel> _deleteCommand;
        public DelegateCommand<TodoModel> DeleteCommand =>
                    _deleteCommand ?? (_deleteCommand = new DelegateCommand<TodoModel> (ExecuteDeleteCommand));
        void ExecuteDeleteCommand(TodoModel parameter)
        {
            //MessageViewModel msg = new MessageViewModel();
            //msg.Message = parameter.TodoModelId.ToString();

            //manager.ShowWindow(msg);
            var result = unitofWork.catchResult(unitofWork.ListServices.RemoveList(parameter));
            MessageBox.Show(result);
            GetList();
            //parameter.TodoModelId
            //https://www.youtube.com/watch?v=IRE2PAD1kIM
        }
        //========================================================== Edit Commnad
        private DelegateCommand<TodoModel> _editCommand;
        public DelegateCommand<TodoModel> EditCommand =>
                    _editCommand ?? (_editCommand = new DelegateCommand<TodoModel>(ExecuteEditCommand));
        void ExecuteEditCommand(TodoModel parameter)
        {
         
            CreateTodoViewModel TodoWindow = new CreateTodoViewModel();
            
            TodoWindow.Id = parameter.TodoModelId;
            TodoWindow.Name = parameter.Name;
            TodoWindow.Description = parameter.Description;

            manager.ShowDialog(TodoWindow);

            
            GetList();
        }
        //========================================================== View Item Commnad
        private DelegateCommand<TodoModel> _viewCommand;
        public DelegateCommand<TodoModel> ViewCommand =>
                    _viewCommand ?? (_viewCommand = new DelegateCommand<TodoModel>(ExecuteViewCommand));
         
        void ExecuteViewCommand(TodoModel parameter)
        {


            //MessageViewModel msg = new MessageViewModel();
            //msg.Message = parameter.TodoModelId.ToString();

            //manager.ShowWindow(msg);

            //var b = unitofWork.ItemServices.LoadItem(parameter.TodoModelId);
            //foreach (ItemModel a in b)
            //{
            //    MessageBox.Show(a.ItemModelId + "");
            //}
            
            ItemsDataGrid = new BindableCollection<ItemModel>(unitofWork.ItemServices.LoadItem(parameter.TodoModelId));
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
