﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace TodoApp.API.Data
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetTodoItemsById(int id);
        Task<Item> GetItemById(int id);

        Task CreateItem(Item data);
        Task UpdateItem(Item data);
        Task DeleteItem(Item data);
        bool SaveChanges();
    }
}
