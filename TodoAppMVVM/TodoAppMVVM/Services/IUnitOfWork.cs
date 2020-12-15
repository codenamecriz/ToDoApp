using System.Collections.Generic;

namespace TodoAppMVVM.Services
{
    public interface IUnitOfWork
    {
        IItemService ItemServices { get; }
        ITodoService ListServices { get; }

        string catchResult(List<string> actionResult);
    }
}