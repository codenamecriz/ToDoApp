using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureManagement.Api.Features
{
    [FilterAlias("BrowserFilter")]
    public class BrowserFeatureFilter : IFeatureFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BrowserFeatureFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            var userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();
            var settings = context.Parameters.Get<BrowserFilterSettings>();
            Console.WriteLine(">>>>>>>>>>>"+ settings.AllowedBrowsers);
            return Task.FromResult(settings.AllowedBrowsers.Any(userAgent.Contains));
        }
    }
    public class BrowserFilterSettings
    {
        public string[] AllowedBrowsers { get; set; }
    }
}
