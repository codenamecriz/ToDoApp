using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.MVVM.Helpers.RequestApi;
using TodoApp.MVVM.Models;
using TodoAppMVVM.Repository;

namespace TodoApp.MVVM.Services
{
    public class QueryService : IQueryService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IRequestApi _request ;

        public QueryService(ITodoRepository todoRepository, IItemRepository itemRepository, IRequestApi request)
        {
            _todoRepository = todoRepository;
            _itemRepository = itemRepository;
            _request = request;
        }
        #region Service Get All Todo Data
        public async Task<List<TodoListDTO>> GetAll()
        {
            
            List<TodoListDTO> todoList = new List<TodoListDTO>();
            try
            {
                var query = await _request.TodoGetRequest.GetAllTodoAsync();
                //var query = _todoRepository.GetAllDatalist();
                foreach (var list in query)
                {
                    todoList.Add(new TodoListDTO { Id = list.Id, Name = list.Name, Description = list.Description });
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return todoList;
        }
        #endregion

        #region Service Get Item By Id
        public async Task< List<ItemDTO>> GetItemById(int id)
        {
            List<ItemDTO> ObjItems = new List<ItemDTO>();
            try
            {
                //var ObjQuery = from obj in ObjContext.Employees
                //               select obj;
                var query = await _request.ItemGetRequest.GetItemByIdAsync(id);
                //var query = _itemRepository.GetItemById(id);
                foreach (var list in query)
                {
                    ObjItems.Add(new ItemDTO
                    {
                        Id = list.Id,
                        Name = list.Name,
                        Details = list.Details,
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


        
        //TodoListGrid = new ObservableCollection<TodoListDTO>(todoDto); 

        //    
        //ItemsGrid = new ObservableCollection<ItemDTO>(itemDto);
    }
}
