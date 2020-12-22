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
        ITodoService listServices;// = new TodoService();
        IItemService itemServices; //= new ItemService();
        IQueryService todoListService;
        public UnitOfWork(ITodoService _listServices, IItemService _itemServices, IQueryService _todoListService)//ITodoService _listServices, IItemService _itemServices)//IItemService _itemService, IListService _listService)
        {
            listServices = _listServices;
            itemServices = _itemServices;
            todoListService = _todoListService;
            //itemServices = _itemServices;
            //listServices = _listServices;

        }
        public string catchResult(List<string> actionResult) // ----> CatchResult Message
        {
            if (actionResult[1] == "true")
            { ListServices.Save(); ItemServices.Save(); } //-------> Saving Data

            return actionResult[0];
        }
        public ITodoService ListServices // -------> 
        {
            get
            {
                //if (this.listServices == null)
                //{
                //    this.listServices = new TodoService();
                //}
                return listServices;
            }
        }


        public IItemService ItemServices // -------> 
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
        
        public IQueryService QeuriesServices // -------> 
        {
            get
            {
                //if (this.todoListService == null)
                //{
                //    this.todoListService = new QueryService();
                //}
                return todoListService;
            }
        }

    }
}
//https://www.youtube.com/watch?v=CRatpHRVZ3c

//-------> Factory patern -> https://www.youtube.com/watch?v=I2il8ZsDkLU