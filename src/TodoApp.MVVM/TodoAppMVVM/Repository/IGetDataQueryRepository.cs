using System.Collections.Generic;
using TodoAppMVVM.Models;

namespace TodoApp.MVVM.Repository
{
    public interface IGetDataQueryRepository
    {
        IEnumerable<ItemModel> GetAllItem(int id);
        IEnumerable<TodoModel> GetAllDatalist();
    }
}