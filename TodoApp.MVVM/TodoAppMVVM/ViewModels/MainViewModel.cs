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

namespace TodoAppMVVM.ViewModels
{
    public class MainViewModel : Screen 
    {
        IWindowManager manager = new WindowManager();
      
        public BindableCollection<TodoModel> listDataGrid { get; set; }
        public BindableCollection<ItemModel> itemsDataGrid { get; set; }

        //private readonly IBuildConnection _dbConnect;

        //private readonly IUnitOfWork unitofWork;

        private readonly BuildConnection _dbConnect;

        private readonly UnitOfWork unitofWork;

        private readonly DBContext createDb = new DBContext();
        public MainViewModel()//IBuildConnection dbConnect, IUnitOfWork _unitofWork)//IGetAllTodoQuery _TodoQuery, IGetAllItemQuery _ItemQuery
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
            GetList();
            
        }
        private void GetList()
        {

            //var container = App.Configure();
            //var _listDbContext = container.Resolve<IDetalistRepository>();
            //var _itemDbContext = container.Resolve<IItemRepository>();

            listDataGrid = new BindableCollection<TodoModel>(unitofWork.ListServices.LoadList());
            itemsDataGrid = new BindableCollection<ItemModel>(unitofWork.ItemServices.LoadItem(1));

            //itemsDataGrid.ItemsSource = _itemDbContext.GetAll(ListDataId);
            listDataGrid.Refresh();
            itemsDataGrid.Refresh();
            // bind to the source

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
            CreateTodoViewModel TodoWindow = new CreateTodoViewModel();

            TodoWindow.Id = 1;
            TodoWindow.Name = "pass name";
            TodoWindow.Description = "pass description";

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
        private DelegateCommand<TodoModel> _deleteCommand;
        public DelegateCommand<TodoModel> DeleteCommand =>
                    _deleteCommand ?? (_deleteCommand = new DelegateCommand<TodoModel> (ExecuteDeleteCommand));
        void ExecuteDeleteCommand(TodoModel parameter)
        {
            unitofWork.ListServices.RemoveList(parameter);
            //parameter.TodoModelId
            //https://www.youtube.com/watch?v=IRE2PAD1kIM
        }


    }
    
}
