using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.MVVM.Models;
using TodoApp.MVVM.Models.ValueObject;
using TodoAppMVVM.Models;

namespace TodoApp.MVVM.Helpers.RequestApi.RequestCommands.RequestTodo
{
    public class TodoSendRequest : ITodoSendRequest
    {
        private readonly IRequestConfig _requestConfig;
        private RestRequest request;
        public TodoSendRequest(IRequestConfig requestConfig)
        {
            _requestConfig = requestConfig;
        }

        public async Task<ResponseResultApi> PostAsync(TodoListDTO postData)
        {
            request = new RestRequest(_requestConfig.TodoRoute(), Method.POST);
          
            request.AddJsonBody(postData);
            var response = await Task.FromResult(_requestConfig.ClientAddress().Execute(request));

            //Console.WriteLine(response.Content);
            //var json = new JavaScriptSerializer().Serialize(response);
            var resContent = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content).ToString();
            

            ResponseResultApi result = new ResponseResultApi ();
            result.Error = false;
          
            if (resContent.Contains("error") || resContent.Contains("Error") || resContent.Contains("ERROR"))
            {
                var responseSplited1 = resContent.Split('{');
                var responseSplited2 = responseSplited1[2].Split('}');
                var responseSplited3 = responseSplited2[0].Split(',');
                var fieldName = responseSplited3[0].Split(':');
                var errorInfo = responseSplited3[1].Split(':');

                result.Error = true;
                    result.TagName = "Todo";
                    result.FieldName = fieldName[1];//fieldName[1],
                    result.ErrorInformation = errorInfo[1];//errorInfo[1],
                    result.TodoContent = postData;
                    result.ItemContent = null;
                
                Console.WriteLine("Error Find<-------------------------<");
            }

            //var json = JSON.stringify(response);
            //Console.WriteLine("--> " + a);

            return result;//result.ErrorInformation;
        }

        public async void PutAsync(Todo putData)
        {
            request = new RestRequest(_requestConfig.TodoByIdRoute(putData.Id), Method.PUT);
         
            request.AddJsonBody(putData);
            var responses = await Task.FromResult(_requestConfig.ClientAddress().Execute(request));
        }

        public async Task<string> DeleteAsync(int id)
        {
            request = new RestRequest(_requestConfig.TodoByIdRoute(id), Method.DELETE);

            var responses = await Task.FromResult(_requestConfig.ClientAddress().Execute(request));
            return responses.Content;
        }
    }
}
