using System.Collections.Generic;
using TodoApp.MVVM.Services;

namespace TodoAppMVVM.Services
{
    public interface IUnitOfWork
    {
        IItemService ItemServices { get; }
        ITodoService ListServices { get; }

        IQueryService QeuriesServices { get; }

        string catchResult(List<string> actionResult);
    }
}