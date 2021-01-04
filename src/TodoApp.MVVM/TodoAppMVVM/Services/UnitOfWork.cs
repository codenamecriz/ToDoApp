using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.MVVM.Services;

namespace TodoAppMVVM.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITodoService todoServices;
        private readonly IItemService itemServices;
        private readonly IQueryService queryService;
        public UnitOfWork(ITodoService _todoServices, 
                        IItemService _itemServices, 
                        IQueryService _queryService)
        {
            todoServices = _todoServices;
            itemServices = _itemServices;
            queryService = _queryService;
        }

        #region Catch the Result of Services
        public string CatchResult(List<string> actionResult) 
        {
            if (actionResult[1] == "true")
            {
                //Saving Data
                TodoServices.Save(); 
                ItemServices.Save(); 
            } 

            return actionResult[0];
        }
        #endregion

        #region Todo Command Services
        public ITodoService TodoServices // -------> todo command
        {
            get
            {
                /*if (this.listServices == null)
                {
                    this.listServices = new TodoService();
                }*/
                return todoServices;
            }
        }
        #endregion

        #region Item Command Services
        public IItemService ItemServices 
        {
            get
            {
                /*if (this.itemServices == null)
                {
                    this.itemServices = new ItemService();
                }*/
                return itemServices;
            }
        }
        #endregion

        #region Query Services
        public IQueryService QeuriesServices 
        {
            get
            {
                /*if (this.todoListService == null)
                {
                    this.todoListService = new QueryService();
                }*/
                return queryService;
            }
        }
        #endregion

    }
}
//https://www.youtube.com/watch?v=CRatpHRVZ3c

//-------> Factory patern -> https://www.youtube.com/watch?v=I2il8ZsDkLU