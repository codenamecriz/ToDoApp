using Caliburn.Micro;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.MVVM.Helpers.RequestApi;
using TodoApp.MVVM.Helpers.RequestApi.RequestCommands.RequestItem;
using TodoApp.MVVM.Helpers.RequestApi.RequestCommands.RequestTodo;
using TodoApp.MVVM.Helpers.RequestApi.RequestQueries.RequestItem;
using TodoApp.MVVM.Helpers.RequestApi.RequestQueries.RequestTodo;
using TodoApp.MVVM.IViewModels;
using TodoApp.MVVM.Services;
using TodoAppMVVM.Repository;
using TodoAppMVVM.Services;
using TodoAppMVVM.SQLite;
using TodoAppMVVM.ViewModels;

namespace TodoApp.MVVM
{
    public class NinjectConfiguration
    {
        public IKernel Configure()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IBuildConnection>().To<BuildConnection>();
            kernel.Bind<IWindowManager>().To<WindowManager>();
            kernel.Bind<ICreateTodoViewModel>().To<CreateTodoViewModel>();
            kernel.Bind<ICreateItemViewModel>().To<CreateItemViewModel>();
          
            kernel.Bind<IQueryService>().To<QueryService>();
            kernel.Bind<ITodoService>().To<TodoService>();
            kernel.Bind<IItemService>().To<ItemService>();
            kernel.Bind<IItemRepository>().To<ItemRepository>();
            kernel.Bind<ITodoRepository>().To<TodoRepository>();
            kernel.Bind<IKernel>().To<StandardKernel>();
            kernel.Bind<IDBContext>().To<DBContext>();

          

            //--> API Config
            kernel.Bind<IRequestApi>().To<RequestApi>();
            kernel.Bind<IRequestConfig>().To<RequestConfig>();

            kernel.Bind<ITodoGetRequest>().To<TodoGetRequest>();
            kernel.Bind<ITodoSendRequest>().To<TodoSendRequest>();

            kernel.Bind<IItemGetRequest>().To<ItemGetRequest>();
            kernel.Bind<IItemSendRequest>().To<ItemSendRequest>();



            return kernel;
        }
    }
}
