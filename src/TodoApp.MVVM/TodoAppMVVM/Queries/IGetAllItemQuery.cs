using System.Collections.Generic;
using TodoAppMVVM.Models;

namespace TodoAppMVVM.Queries
{
    public interface IGetAllItemQuery
    {
        IEnumerable<ItemModel> GetAllById(int id);
    }
}