using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureManagement.Api.Features
{
    public class ProdTestAccountsFilter : IFeatureFilter
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProdTestAccountsFilter(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            var userName = _configuration["userName"];
            var listOfAllowedUsers = context.Parameters.Get<List<string>>();
            var isProductionEnv = _webHostEnvironment.IsProduction();

            return Task.FromResult(listOfAllowedUsers != null && listOfAllowedUsers.Contains(userName) && isProductionEnv);
        }
    }
}
