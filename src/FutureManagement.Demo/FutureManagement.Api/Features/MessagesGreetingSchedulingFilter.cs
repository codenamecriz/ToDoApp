using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureManagement.Api.Features
{
    [FilterAlias("MessagesGreetings")]
    public class MessagesGreetingSchedulingFilter : IFeatureFilter
    {
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {

            DateTime dateTime = DateTime.UtcNow.Date;
            var _date = dateTime.ToString("dd/MM/yyyy");
            var _time = DateTime.Now.ToString("h:mm tt");
            var paramTime = context.Parameters.Get<TimeSet>();

            Console.WriteLine("Hours: "+ _time + "----"+ paramTime.Set[0]);
            var container = ClientInfo.ClientContainers();

            

            foreach (var item in container)
            {
                //Console.WriteLine(item.BirthDate);
                if (item.BirthDate == _date && _time == paramTime.Set[0])
                { Console.WriteLine(paramTime.Set[1] + "  " + item.Name); }
            }

           
            return Task.FromResult(true);
        }
    }

    //02 / 11/2021 3:39:31 pm
    public static class ClientInfo
    {
         //IEnumerable<Client> ClientContainer = new IEnumerable<Client>();
      
        public static IEnumerable<Client> ClientContainers()
        {
            List<Client> ClientContainer = new List<Client>();
            ClientContainer.Add(new Client { Name = "John", BirthDate = "11/02/2021" });
            ClientContainer.Add(new Client { Name = "James", BirthDate = "12/02/2021"});
            ClientContainer.Add(new Client { Name = "Tim", BirthDate = "11/02/2021"});

            return ClientContainer;
        }
    }

    public class Client
    {
        public string Name { get; set; }
        public string BirthDate { get; set; }
    }
    public class TimeSet
    {
        public string[] Set { get; set; }
        //public string[] Message { get; set; }

    }
}
