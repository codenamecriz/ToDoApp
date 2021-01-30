
using Handlers.Commands;
using Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace TodoApp.API.Controllers
{
    [Route("item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }


        #region GetItemBy(TodoId): /item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemResponseDto>> GetAllItem(int id)
        {
            var query = new GetTodoItemsByIdRequest(id);
            var result = await _mediator.Send(query); 
            return Ok(result);
        }
        #endregion

        #region GetItemBy(PrimaryId): /item/pk/5
        
        [HttpGet("pk/{id}", Name = "GetItemById")]
        public async Task<ActionResult<ItemReadDto>> GetItemById(int id)
        {

            var query = new GetItemByIdRequest(id);
            var result = await _mediator.Send(query);
            return result != null ? (ActionResult)Ok(result) : NotFound();

        }
        #endregion

        #region POST: /item
        
        [HttpPost]
        public async Task<ActionResult<ItemReadDto>> CreateItem(CreateItemRequest request)
        {
            //if (!ModelState.IsValid)
            //{
                
            //}
            var result = await _mediator.Send(request);

            return result != null ? (ActionResult)CreatedAtAction(nameof(GetItemById), new { Id = result.Id }, result) : BadRequest();

        }
        #endregion

        #region PUT: /item/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(int id, ItemUpdateDto request)
        {
            var result = await _mediator.Send(new UpdateItemRequest(id, request));
            return result != null ? (ActionResult)NoContent() : NotFound();

        }
        #endregion

        #region PATCH: /item/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchItem(int id, JsonPatchDocument<ItemUpdateDto> pathDoc) 
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

        #region DELETE: /item/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            var result = await _mediator.Send(new DeleteItemRequest( id));
            return result != null ? (ActionResult)NoContent() : NotFound();

        }
        #endregion

        #region Test Return: /item/test
    
        //[HttpGet("test")]
        //public ActionResult Test()
        //{
        //    var test = new List<Item>();
        //    test.Add(new Item
        //    {
        //        Name = "test name",
        //        Details = "test details",
        //        Status = Enum.EnumItemStatus.Done,
        //        TodoId = 1
        //    });
        //    return Ok(test);

        //}
        #endregion
    }
}
