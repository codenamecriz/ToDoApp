using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.MVVM.Services;

namespace TodoAppMVVM.Services
{
    public class UnitOfWork : IUnitOfWork
    {

        //private readonly ITodoService listServices;
        //private readonly IItemService itemServices;
        ITodoService todoServices;// = new TodoService();
        IItemService itemServices; //= new ItemService();
        IQueryService queryService;
        public UnitOfWork(ITodoService _todoServices, IItemService _itemServices, IQueryService _queryService)//ITodoService _listServices, IItemService _itemServices)//IItemService _itemService, IListService _listService)
        {
            todoServices = _todoServices;
            itemServices = _itemServices;
            queryService = _queryService;
            //itemServices = _itemServices;
            //listServices = _listServices;

        }
        public string catchResult(List<string> actionResult) // ----> CatchResult Message
        {
            if (actionResult[1] == "true")
            {
                //-------> Saving Data
                TodoServices.Save(); 
                ItemServices.Save(); 
            } 

            return actionResult[0];
        }
        public ITodoService TodoServices // -------> todo command
        {
            get
            {
                //if (this.listServices == null)
                //{
                //    this.listServices = new TodoService();
                //}
                return todoServices;
            }
        }


        public IItemService ItemServices // -------> item command
        {
            get
            {
                //if (this.itemServices == null)
                //{
                //    this.itemServices = new ItemService();
                //}
                return itemServices;
            }
        }
        
        public IQueryService QeuriesServices // ------->  todo and item query
        {
            get
            {
                //if (this.todoListService == null)
                //{
                //    this.todoListService = new QueryService();
                //}
                return queryService;
            }
        }

    }
}
//https://www.youtube.com/watch?v=CRatpHRVZ3c

//-------> Factory patern -> https://www.youtube.com/watch?v=I2il8ZsDkLU