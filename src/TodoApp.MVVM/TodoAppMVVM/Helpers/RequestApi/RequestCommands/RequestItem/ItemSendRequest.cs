using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMVVM.Models;

namespace TodoApp.MVVM.Helpers.RequestApi.RequestCommands.RequestItem
{
    public class ItemSendRequest : IItemSendRequest
    {
        private readonly IRequestConfig _requestConfig;
        private RestRequest request;
        public ItemSendRequest(IRequestConfig requestConfig)
        {
            _requestConfig = requestConfig;
        }
        public async Task<string> PostAsync(Item postData)
        {
            request = new RestRequest(_requestConfig.ItemRoute(), Method.POST);
            
            request.AddJsonBody(postData);
            var response = await Task.FromResult(_requestConfig.ClientAddress().Execute(request));

            Console.WriteLine(response.Content);
            return response.Content;
        }

        public async Task<string> PutAsync(Item putData)
        {
            request = new RestRequest(_requestConfig.ItemRoute(putData.Id), Method.PUT);

            request.AddJsonBody(putData);
            var responses = await Task.FromResult(_requestConfig.ClientAddress().Execute(request));
            return responses.Content;
        }
        public async Task<string> DeleteAsync(int id)
        {
            request = new RestRequest(_requestConfig.ItemRoute(id), Method.DELETE);
            var responses = await Task.FromResult(_requestConfig.ClientAddress().Execute(request));
            return responses.Content;
        }
    }
}
