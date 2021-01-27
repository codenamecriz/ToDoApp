using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.MVVM.Models;

namespace TodoApp.MVVM.Helpers.RequestApi.RequestQueries.RequestTodo
{
    public class TodoGetRequest : ITodoGetRequest
    {
        private readonly IRequestConfig _requestConfig;

        public TodoGetRequest(IRequestConfig requestConfig)
        {
            _requestConfig = requestConfig;
        }

        public async Task<IEnumerable<TodoListDTO>> GetAllTodoAsync()
        {
            //-----------------> Get Todo
            Console.WriteLine("Get All Todo Data");
            RestRequest request = new RestRequest(_requestConfig.TodoRoute(), Method.GET);
            IRestResponse<List<TodoListDTO>> response = await Task.FromResult(_requestConfig.ClientAddress().Execute<List<TodoListDTO>>(request));
            Console.WriteLine(response.Content);
            return response.Data;
        }

        public async Task<TodoListDTO> GetTodoByIdAsync(int id)
        {
            //-----------------> Get Todo
            Console.WriteLine("Get All Todo Data");
            RestRequest request = new RestRequest(_requestConfig.TodoByIdRoute(id), Method.GET);
            IRestResponse<TodoListDTO> response = await Task.FromResult(_requestConfig.ClientAddress().Execute<TodoListDTO>(request));
            Console.WriteLine(response.Content);
            return response.Data;
        }
    }
}
