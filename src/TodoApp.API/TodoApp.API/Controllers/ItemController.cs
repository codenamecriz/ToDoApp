using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.DTOs.Item;
using TodoApp.API.Handlers.Commands.Items.Create;
using TodoApp.API.Handlers.Commands.Items.Delete;
using TodoApp.API.Handlers.Commands.Items.Patch;
using TodoApp.API.Handlers.Commands.Items.Update;
using TodoApp.API.Handlers.Queries.Items;
using TodoApp.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApp.API.Controllers
{
    [Route("items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        // GET: api/item
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #region GetItemBy(TodoId): /items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemReadDto>> GetAllItem(int id)
        {
            var query = new GetTodoItemsByIdRequest(id);
            var result = await _mediator.Send(query); 
            return Ok(result);
        }
        #endregion

        #region GetItemBy(PrimaryId): /items/item/5
        
        [HttpGet("pk/{id}", Name = "GetItemById")]
        public async Task<ActionResult<ItemReadDto>> GetItemById(int id)
        {

            var query = new GetItemByIdRequest(id);
            var result = await _mediator.Send(query);
            return result != null ? (ActionResult)Ok(result) : NotFound();

        }
        #endregion

        #region POST: /items
        // POST api/items
        [HttpPost]
        public async Task<ActionResult<ItemReadDto>> CreateItem(CreateItemRequest request)
        {
            var result = await _mediator.Send(request);

            return CreatedAtAction(nameof(GetItemById), new { Id = result.Id }, result);


        }
        #endregion

        #region PUT: /items/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(int id, ItemUpdateDto request)
        {
            var result = await _mediator.Send(new UpdateItemRequest(id, request));//.Name, dataDto.Description));
            return result != null ? (ActionResult)NoContent() : NotFound();

        }
        #endregion

        #region PATCH: /items/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchItem(int id, JsonPatchDocument<ItemUpdateDto> pathDoc) //------------- Target the espisific filed to update
        {
            var resultFromRepo = await _mediator.Send(new PatchItemRequest(id, null));
            if (resultFromRepo == null)
            {
                return NotFound();
            }
            var toPatch = resultFromRepo;
            pathDoc.ApplyTo(toPatch, ModelState);
            if (!TryValidateModel(toPatch))
            {
                return ValidationProblem(ModelState);
            }
            var saveResult = await _mediator.Send(new PatchItemRequest(id, toPatch));


            return NoContent();

        }
        #endregion

        #region DELETE: /items/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            var result = await _mediator.Send(new DeleteItemRequest(id));
            return result != null ? (ActionResult)NoContent() : NotFound();

        }
        #endregion
    }
}
