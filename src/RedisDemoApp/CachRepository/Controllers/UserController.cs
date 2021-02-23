using CachRepository.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachRepository.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IDistributedCache _Cache;
        public UserController(IDistributedCache distributedCache) => _Cache = distributedCache;

        [HttpGet("{name}")]
        public async Task<User> GetUser(string name)
        {

            User user = !string.IsNullOrEmpty(name) ? await RedisCache.GetObjectAsync<User>(_Cache, name) : null;//new User();

            //if (!string.IsNullOrEmpty(name))
            //{

            //    user = await RedisCache.GetObjectAsync<User>(_Cache, name);
               
            //}
            return user;
        }
        [HttpPost("{key}")]
        public async Task<ActionResult> SetUser(string key, User value)
        {
             Console.WriteLine(key + "-" + value.Name);
            await RedisCache.SetObjectAsync<User>(_Cache, key, value);

            return NoContent();
        }
    }

    

}
