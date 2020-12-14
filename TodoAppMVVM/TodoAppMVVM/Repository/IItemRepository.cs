using System;
using System.Collections.Generic;
using System.Text;
using TodoAppMVVM.Models;

namespace TodoAppMVVM.Repository
{
    public interface IItemRepository
    {
        //IEnumerable<ItemModel> GetAll(int id);
        string Add(ItemModel data);
        string Update(ItemModel data);
        void Delete(int id);
      
    }
}
