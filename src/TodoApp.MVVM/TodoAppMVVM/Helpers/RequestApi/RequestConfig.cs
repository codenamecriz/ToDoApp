using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.MVVM.Helpers.RequestApi
{
    public class RequestConfig : IRequestConfig
    {
        public RestClient ClientAddress()
        {
            RestClient client = new RestClient("https://localhost:5001/");// //https://localhost:49154/
            return client;
        } 
        public string TodoRoute()
        {
            return "todo/";
        }
        public string TodoByIdRoute(int id)
        {
            return "todo/" + id;
        }

        public string ItemRoute()
        {
            return "item/";
        }
        public string ItemRoute(int id)
        {
            return "item/" + id;
        }
        public string ItemPkIdRoute(int id)
        {
            return "item/pk/" + id;
        }
    }
}
