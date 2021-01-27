using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Services.IRepository;
using TodoApp.API.Models;

namespace Services
{
    public class DbAutentication : IDbAuthentication
    {
        private readonly IItemRepository _itemRepository;
        private readonly ITodoRepository _todoRepository;

        private List<Todo> todoContainer = new List<Todo>();
        private List<Item> itemContainer = new List<Item>();

        public DbAutentication(IItemRepository itemRepository, ITodoRepository todoRepository)
        {
            _itemRepository = itemRepository;
            _todoRepository = todoRepository;

            
            
        }

        
        public async Task<int> CheckingIfExist(Todo data)
        {
            todoContainer.AddRange((IEnumerable<Todo>) await _todoRepository.GetAllTodo());
            var value = 0;
            foreach (var todoItem in todoContainer)
            {
                if (todoItem.Name == data.Name)
                {
                    value = 1;
                }
            }
            return value;
        }
        public async Task<int>  CheckingIfExist(Item data)
        {
            itemContainer.AddRange((IEnumerable<Item>) await _itemRepository.GetAllItem());
            var value = 0;
            foreach (var Item in itemContainer)
            {
                if (Item.Name == data.Name)
                {
                    value = 1;
                }
            }
            return value;
        }

        //private int ValidatingProcess(Todo data)
        //{
        //    var value = 0;
        //    foreach (var todoItem in dataContainer)
        //    {
        //        if (todoItem.Name == data)
        //        {
        //            value = 1;
        //        }
        //    }
        //    return value;
        //}
    }
}
