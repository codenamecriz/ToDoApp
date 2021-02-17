using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureManagement.Api.Features
{
    public class DevEnvFilter : IFeatureFilter
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DevEnvFilter(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            return Task.FromResult(_webHostEnvironment.IsDevelopment());
        }
    }
}
