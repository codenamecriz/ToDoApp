using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.MVVM.Models;

namespace TodoApp.MVVM.Helpers.RequestApi.RequestQueries.RequestItem
{
    public class ItemGetRequest : IItemGetRequest
    {
        private readonly IRequestConfig _requestConfig;

        public ItemGetRequest(IRequestConfig requestConfig)
        {
            _requestConfig = requestConfig;
        }
        //public async Task<IEnumerable<ItemDTO>> GetAllItemAsync()
        //{
        //    Console.WriteLine("Get All Todo Data");
        //    RestRequest request = new RestRequest(_requestConfig.TodoByIdRoute(id), Method.GET);
        //    IRestResponse<TodoListDTO> response = await Task.FromResult(_requestConfig.ClientAddress().Execute<TodoListDTO>(request));
        //    Console.WriteLine(response.Content);
        //    return response.Data;
        //}

        public async Task<IEnumerable<ItemDTO>> GetItemByIdAsync(int id)
        {
            Console.WriteLine("Get All Todo Data");
            RestRequest request = new RestRequest(_requestConfig.ItemRoute(id), Method.GET);
            IRestResponse<List<ItemDTO>> response = await Task.FromResult(_requestConfig.ClientAddress().Execute<List<ItemDTO>>(request));
            var itemDto = new List<ItemDTO>();
            foreach (var item in response.Data)
            {
                var status = "Done";
                if (item.Status == "0")
                { status = "Pending"; }
                itemDto.Add(new ItemDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Details = item.Details,
                    Status = status

                }) ;
            }
            Console.WriteLine(response.Content);
            return itemDto;
        }

        public async Task<ItemDTO> GetItemByPkIdAsync(int id)
        {
            Console.WriteLine("Get All Todo Data");
            RestRequest request = new RestRequest(_requestConfig.ItemPkIdRoute(id), Method.GET);
            IRestResponse<ItemDTO> response = await Task.FromResult(_requestConfig.ClientAddress().Execute<ItemDTO>(request));
            Console.WriteLine(response.Content);
            return response.Data;
        }
    }
}
