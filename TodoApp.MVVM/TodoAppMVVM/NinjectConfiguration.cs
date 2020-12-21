using Caliburn.Micro;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.MVVM.IViewModels;
using TodoApp.MVVM.Repository;
using TodoApp.MVVM.Services;
using TodoAppMVVM.Repository;
using TodoAppMVVM.Services;
using TodoAppMVVM.SQLite;
using TodoAppMVVM.ViewModels;

namespace TodoApp.MVVM
{
    public class NinjectConfiguration
    {

        public NinjectConfiguration()
        {
           
        }
        public IKernel Configure()//object sender, StartupEventArgs e)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IBuildConnection>().To<BuildConnection>();
            kernel.Bind<IWindowManager>().To<WindowManager>();
            kernel.Bind<ICreateTodoViewModel>().To<CreateTodoViewModel>();
            kernel.Bind<ICreateItemViewModel>().To<CreateItemViewModel>();
            kernel.Bind<IMessageViewModel>().To<MessageViewModel>();
            kernel.Bind<IQueryService>().To<QueryService>();
            kernel.Bind<ITodoService>().To<TodoService>();
            kernel.Bind<IItemService>().To<ItemService>();
            kernel.Bind<IGetDataQueryRepository>().To<GetDataQueryRepository>();
            kernel.Bind<IItemRepository>().To<ItemRepository>();
            kernel.Bind<ITodoRepository>().To<TodoRepository>();

            return kernel;
        }
    }
}
