using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Caliburn.Micro;
using TodoApp.MVVM.IViewModels;
using TodoAppMVVM.Repository;
using TodoAppMVVM.Services;
using TodoAppMVVM.SQLite;
using TodoAppMVVM.ViewModels;
using TodoAppMVVM.Views;

namespace TodoAppMVVM
{
    public class Bootstrapper : BootstrapperBase
    {
        //private const string ModuleFilePrefix = "CaliburnAndAutofac";
        //private IContainer _container;

        //protected override void BuildUp(object instance)
        //{
        //    _container.InjectProperties(instance);
        //}




        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            //context.CreateDb();

            Initialize();
        }
        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            //_container.RegisterInstance(typeof(CreateTodoViewModel), null, typeof(IUnitOfWork));
            //_container.RegisterSingleton(typeof(CreateTodoViewModel), null, typeof(CreateTodoViewModel));

            _container
               .PerRequest<DBContext>();
            _container
               .PerRequest<SQLiteDataReader>();

            //_container
            //    .Singleton<CreateTodoViewModel>();
            //_container
            //   .Singleton<MainViewModel>();

            //_container
            //    .PerRequest<IGetAllTodoQuery, GetAllTodoQuery>();
            //_container
            //    .PerRequest<IGetDataQueryRepository, GetDataQueryRepository>();
            //_container
            //   .PerRequest<IGetAllItemQuery, GetAllItemQuery>();
            _container
               .Singleton<IUnitOfWork, UnitOfWork>();
            _container
               .PerRequest<ITodoService, TodoService>();
            _container
               .PerRequest<IItemService, ItemService>();
            _container
               .PerRequest<ITodoRepository, TodoRepository>();
            _container
               .PerRequest<IItemRepository, ItemRepository>();
            _container
               .PerRequest<IBuildConnection, BuildConnection>();
            _container
               .PerRequest<IMainViewModel, MainViewModel>();





            GetType().Assembly.GetTypes()
                .Where(t => t.IsClass)
                .Where(t => t.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));

        }
        protected override void OnStartup(object Sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}

//https://www.youtube.com/watch?v=8E000zu8UhQ