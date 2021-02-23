using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Redis_With_StackExchange.Domain.Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redis_With_StackExchange.Services.Cache
{
    public class RedisCacheService : ICacheService
    {
        //private readonly IDistributedCache _Cache;
        private readonly IConnectionMultiplexer _Cache;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer) => _Cache = connectionMultiplexer;

        //public RedisCacheService(IDistributedCache distributedCache) => _Cache = distributedCache;

        // get
        public async Task<IEnumerable<T>> GetObjectAsync<T>(string key)
        {
            var db =  _Cache.GetDatabase();
            var value = await db.StringGetAsync(key);
            return string.IsNullOrEmpty(value) ? default(IEnumerable<T>) : JsonConvert.DeserializeObject< IEnumerable<T>>(value);
        }

        // save
        public async Task SetObjectAsync<T>(string key, T value)
        {
            var db = _Cache.GetDatabase();
            //await db.StringSetAsync(key, obj);
            await db.StringSetAsync(key, JsonConvert.SerializeObject(value));
        }
        
        // verify if an object exists
        public async Task<bool> ExistObjectAsync<T>( string key)
        {
            var db = _Cache.GetDatabase();
            var value = await db.StringGetAsync(key);

            return string.IsNullOrEmpty(value) ? false : true;
        }

        public async void SaveRedisBigData(string key, string value) // save to cache
        {
            //var item = ItemContainer();
            var db = _Cache.GetDatabase();

           
            await db.StringSetAsync(key, value);
           
        }

        public List<Item> ItemContainer()
        {
            var item = new List<Item>();
            item.Add(new Item { Id = 3, Name = "tim", Details = "boy" });
            item.Add(new Item { Id = 4, Name = "John",Details = "girl"});
            item.Add(new Item { Id = 5, Name = "jake", Details = "abcd" });

            return item;
        }
    }
  
}
