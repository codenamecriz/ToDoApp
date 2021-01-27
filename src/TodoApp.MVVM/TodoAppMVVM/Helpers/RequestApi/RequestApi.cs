using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.MVVM.Helpers.RequestApi.RequestCommands.RequestItem;
using TodoApp.MVVM.Helpers.RequestApi.RequestCommands.RequestTodo;
using TodoApp.MVVM.Helpers.RequestApi.RequestQueries.RequestItem;
using TodoApp.MVVM.Helpers.RequestApi.RequestQueries.RequestTodo;
using TodoApp.MVVM.Models;

namespace TodoApp.MVVM.Helpers.RequestApi
{
    public class RequestApi : IRequestApi
    {
       // private static RestClient client = new
       //RestClient("https://localhost:5001/");// //https://localhost:49154/
        // private string route = "";

        // public async Task<IEnumerable<TodoListDTO>> GetAllTodoAsync()
        // {
        //     route = "todo";
        //     //-----------------> Get Todo
        //     Console.WriteLine("Get All Todo Data");
        //     RestRequest request = new RestRequest(route, Method.GET);
        //     IRestResponse<List<TodoListDTO>> response = await Task.FromResult(client.Execute<List<TodoListDTO>>(request));
        //     Console.WriteLine(response.Content);
        //     return response.Data;
        // }

        //public async Task<IEnumerable<ItemDTO>> GetTodoItemsByIdAsync(int id)
        //{
        //    var route = "item/" + id;
        //    //-----------------> Get
        //    Console.WriteLine("Get All Item");
        //    RestRequest request = new RestRequest(route, Method.GET);
        //    IRestResponse<List<ItemDTO>> response = await Task.FromResult(client.Execute<List<ItemDTO>>(request));
        //    Console.WriteLine(response.Content);
        //    return response.Data;
        //}

        private readonly ITodoGetRequest _todoGetRequest;
        private readonly ITodoSendRequest _todoSendRequest;
        private readonly IItemGetRequest _itemGetRequest;
        private readonly IItemSendRequest _itemSendRequest;



        public RequestApi(ITodoGetRequest todoGetRequest, IItemGetRequest itemGetRequest,
                        ITodoSendRequest todoSendRequest, IItemSendRequest itemSendRequest)
        {
            _todoGetRequest = todoGetRequest;
            _itemGetRequest = itemGetRequest;
            _todoSendRequest = todoSendRequest;
            _itemSendRequest = itemSendRequest;
        }

        public ITodoGetRequest TodoGetRequest
        {
            get
            {
                return _todoGetRequest;
            }
        }
        public ITodoSendRequest TodoSendRequest
        {
            get
            {
                return _todoSendRequest;
            }
        }

        public IItemGetRequest ItemGetRequest
        {
            get
            {
                return _itemGetRequest;
            }
        }

        public IItemSendRequest ItemSendRequest
        {
            get
            {
                return _itemSendRequest;
            }
        }
    }
}
