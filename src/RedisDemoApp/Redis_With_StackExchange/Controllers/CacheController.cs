using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Redis_With_StackExchange.Domain.Entities;
using Redis_With_StackExchange.Services.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redis_With_StackExchange.Controllers
{
    [Route("item")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public CacheController(ICacheService cache) => _cacheService = cache;
       
        [HttpGet("{key}")]
        public async Task<IEnumerable<Item>> GetItem(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }
            var item = new List<Item>();
            if (await _cacheService.ExistObjectAsync<Item>(key) == true)
            {
                //var item = !string.IsNullOrEmpty(key) ? 
                //item = await _cacheService.GetObjectAsync<Item>(key);

            }
            else
            {
                // For Demo Purpose
                var items = new List<Item>();
                items.Add(new Item { Id = 3, Name = "tim", Details = "boy" });
                items.Add(new Item { Id = 4, Name = "John", Details = "girl" });
                items.Add(new Item { Id = 5, Name = "jake", Details = "abcd" });
                string jsonItem = JsonConvert.SerializeObject(items);
                 _cacheService.SaveRedisBigData(key, jsonItem);
                
            }
            item.AddRange( await _cacheService.GetObjectAsync<Item>(key));
            return item;
        }
        [HttpPost("{key}")]
        public async Task SetItem(string key, Item item) 
        {
            await _cacheService.SetObjectAsync<Item>(key, item);
            //return Task.CompletedTask;
        }
    }
}
