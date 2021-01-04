using System.Collections.Generic;
using TodoApp.MVVM.Services;

namespace TodoAppMVVM.Services
{
    public interface IUnitOfWork
    {
        IItemService ItemServices { get; }
        ITodoService TodoServices { get; }

        IQueryService QeuriesServices { get; }

        string CatchResult(List<string> actionResult);
    }
}