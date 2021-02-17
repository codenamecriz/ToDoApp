using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureManagement.Api.Features
{
    public class SwitchFilter : IFeatureFilter
    {
        private readonly IConfiguration _configuration;

        public SwitchFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {

            var settings = context.Parameters.Get<SwitchSettings>();
            

            //var userName = _configuration["userName"];
            Console.WriteLine(">>>----"+ settings.Set[0]);

            if (settings.Set[0] == "On")
            {
                Console.WriteLine("Switch is On.");
            }
            else 
            {
                Console.WriteLine("Switch is Off.");
            }

            return Task.FromResult(true);
            //throw new NotImplementedException();
        }
    }

    public class SwitchSettings
    {
        public string[] Set { get; set; }
    }
}
