using EasyCaching.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisDemo2.Controllers
{
    [ApiController]
    [Route("/redis")]
    public class RedisController : ControllerBase
    {
        private readonly IEasyCachingProvider _cachingProvider;
        private readonly IEasyCachingProviderFactory _cachingProviderFactory;

        public RedisController(IEasyCachingProviderFactory cachingProviderFactory)
        {
            _cachingProviderFactory = cachingProviderFactory;
            _cachingProvider = _cachingProviderFactory.GetCachingProvider("redis1");
        }

        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<RedisController> _logger;

        //public RedisController(ILogger<RedisController> logger)
        //{
        //    _logger = logger;
        //}
        [HttpGet]
        public IActionResult SetItemQueue()
        {
            
            _cachingProvider.Set("TestKey123", "here is the value", TimeSpan.FromDays(100));
            Console.WriteLine("Caching><<<<<<<<<<<");
            return Ok();
        }

        [HttpGet("Get")]
        public IActionResult GetItemInQueue()
        {
            var item = this._cachingProvider.Get<string>("TestKey123");

            return Ok(item);
        }
        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
