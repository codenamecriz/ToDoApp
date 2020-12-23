using System;
using System.Collections.Generic;
using System.Text;
using TodoAppMVVM.Models;

namespace TodoAppMVVM.Repository
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItemById(int id);
        string Add(Item data);
        string Update(Item data);
        void RemoveItem(int id);
      
    }
}
