using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.MVVM.Models;
using TodoApp.MVVM.Repository;

namespace TodoApp.MVVM.Services
{
    public class QueryService : IQueryService
    {
        private readonly IGetDataQueryRepository Query;
        public QueryService(IGetDataQueryRepository query)
        {
            Query = query;
        }
        public List<TodoListDTO> GetAll()
        {
            List<TodoListDTO> ObjTodoList = new List<TodoListDTO>();
            try
            {
                //var ObjQuery = from obj in ObjContext.Employees
                //               select obj;
                var query = Query.GetAllDatalist();
                foreach (var list in query)
                {
                    ObjTodoList.Add(new TodoListDTO { TodoId = list.TodoModelId, Name = list.Name, Description = list.Description });
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return ObjTodoList;
        }
        public List<ItemDTO> GetItemById(int id)
        {
            List<ItemDTO> ObjItems = new List<ItemDTO>();
            try
            {
                //var ObjQuery = from obj in ObjContext.Employees
                //               select obj;
                var query = Query.GetAllItem(id);
                foreach (var list in query)
                {
                    ObjItems.Add(new ItemDTO
                    {
                        ItemId = list.ItemModelId,
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
    }
}
