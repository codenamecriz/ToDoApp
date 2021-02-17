using FutureManagement.Api.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FutureManagement.Api.Controllers
{
    [Route("item")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IFeatureManager _featureManager;

        public ItemController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        // GET: api/<ItemController>
        [FeatureGate(MyFeatureFlags.SwitchFlag)]
        [HttpGet]
        public async Task<IEnumerable<string>> GetAsync()
        {
            //var message = "off";
            //if (await _featureManager.IsEnabledAsync("FeatureSwitch"))
            //{
            //    message = "On";
            //}
      
            
            return await Task.FromResult(new string[] { "value1", "value2" });
        }

        // GET api/<ItemController>/5
        [FeatureGate(MyFeatureFlags.GetItemById)]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        //MessagesGreetings
        
        [FeatureGate(MyFeatureFlags.MessagesGreetings)]
        [Route("bdaygreet")]
        public async Task<IEnumerable<string>> BdayGreet()
        {

            return await Task.FromResult( new string[] { "value1", "value2" });
        }

        //// POST api/<ItemController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ItemController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ItemController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
