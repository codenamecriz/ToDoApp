using System.Collections.Generic;
using TodoAppMVVM.Models;

namespace TodoAppMVVM.Services
{
    public interface IItemService
    {
        //IEnumerable<Item> LoadItem(int Id);
        List<string> Add(Item data);
        List<string> RemoveItem(Item data);
        List<string> Update(Item data);
        void Save();
    }
}