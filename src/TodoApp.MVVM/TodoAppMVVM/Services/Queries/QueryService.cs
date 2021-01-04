using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.MVVM.Models;
using TodoAppMVVM.Repository;

namespace TodoApp.MVVM.Services
{
    public class QueryService : IQueryService
    {
        private readonly ITodoRepository todoRepository;
        private readonly IItemRepository itemRepository;
        public QueryService(ITodoRepository _todoRepository, IItemRepository _itemRepository)
        {
            todoRepository = _todoRepository;
            itemRepository = _itemRepository;
        }
        #region Service Get All Todo Data
        public List<TodoListDTO> GetAll()
        {
            List<TodoListDTO> ObjTodoList = new List<TodoListDTO>();
            try
            {
                //var ObjQuery = from obj in ObjContext.Employees
                //               select obj;
                var query = todoRepository.GetAllDatalist();
                foreach (var list in query)
                {
                    ObjTodoList.Add(new TodoListDTO { Id = list.Id, Name = list.Name, Description = list.Description });
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return ObjTodoList;
        }
        #endregion

        #region Service Get Item By Id
        public List<ItemDTO> GetItemById(int id)
        {
            List<ItemDTO> ObjItems = new List<ItemDTO>();
            try
            {
                //var ObjQuery = from obj in ObjContext.Employees
                //               select obj;
                var query = itemRepository.GetItemById(id);
                foreach (var list in query)
                {
                    ObjItems.Add(new ItemDTO
                    {
                        Id = list.Id,
                        Name = list.Name,
                        Detailed = list.Detailed,
                        Status = list.Status,

                    });
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return ObjItems;
        }
        #endregion
    }
}
