using Domain;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Rabbit.API.Producer.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Rabbit.API.Producer.Handlers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rabbit.API.Producer.Controllers
{
    [Route("publish")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;
        public PublishController(IPublishEndpoint publishEndpoint, IMediator mediator)
        {
            _publishEndpoint = publishEndpoint;
            _mediator = mediator;
        }

        // GET: api/<ValuesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> Post(CreateOrderRequest values)
        {
 
            var a = await _mediator.Send(values);
            //await _publishEndpoint.Publish<Order>(values);
            //PublishMessage _pubMessage = new PublishMessage();
            //_pubMessage.Message_Producer(values);
            //Console.WriteLine("-----> this is rabbit" + values.Name + "<--");
            return Ok(a);
            
            
        }

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
  
}
