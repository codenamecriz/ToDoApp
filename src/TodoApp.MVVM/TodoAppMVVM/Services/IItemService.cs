using System.Collections.Generic;
using TodoAppMVVM.Models;

namespace TodoAppMVVM.Services
{
    public interface IItemService
    {
        IEnumerable<ItemModel> LoadItem(int Id);
        List<string> RegisterNewItem(ItemModel data);
        List<string> RemoveItem(ItemModel data);
        List<string> UpdateItem(ItemModel data);
        void Save();
    }
}