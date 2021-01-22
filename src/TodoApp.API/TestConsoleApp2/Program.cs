
//using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp2
{
    class Program
    {
        private static RestClient client = new
        RestClient("https://localhost:49154/");
        
        static async Task Main(string[] args)
        {
          
            var route = "todo";
            //-----------------> Get
            Console.WriteLine("Get All Data");
            RestRequest request = new RestRequest( route , Method.GET);
            IRestResponse<List<Todo>> response = await Task.FromResult( client.Execute<List<Todo>>(request));
            
            Console.WriteLine( response.Content);
            Console.ReadKey();

            //-----------------> POST
            Console.WriteLine("POST Data");
            request = new RestRequest(route, Method.POST);
            var postData = new Todo { 
                Name = "Bahay",
                Description = "Gibain"
            };
            request.AddJsonBody(postData);
            var responses = client.Execute(request);
            Console.WriteLine(responses.Content);
            Console.ReadKey();

            //------------------ PUT
            var id = 21;
            Console.WriteLine("Update Data ID: " + id);
            request = new RestRequest(route + "/" + id, Method.PUT);
             postData = new Todo
            {
                Name = "Bahay nikuya",
                Description = "Sunugin"
            };
            request.AddJsonBody(postData);
             responses = client.Execute(request);
            Console.WriteLine(responses.Content);
            Console.ReadKey();

            //------------------ Delete
            var idToDelete = 23;
            Console.WriteLine("DELETE Data ID: " + id);
            request = new RestRequest(route + "/" + idToDelete, Method.DELETE);
           
            responses = client.Execute(request);
            Console.WriteLine(responses.Content);
            Console.ReadKey();
            /*---> -https://www.infoworld.com/article/3489481/how-to-consume-an-aspnet-core-web-api-using-restsharp.html
               To make a POST request using RestSharp, you can use the following code:

                    RestRequest request = new RestRequest("Default", Method.POST);
                    request.AddJsonBody("Robert Michael");
                    var response = client.Execute(request);
            */

        }


        public class Todo

        {

            //-------------< Class: Model_Project >-------------

            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }


            //-------------</ Class: Model_Project >-------------

        }

    }
}
