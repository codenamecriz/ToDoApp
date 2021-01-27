
using AutoMapper;
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
    
    [Route("todo")] 
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController( IMediator mediator)
        {
            _mediator = mediator;
        }
        #region GET: /todo
        [HttpGet]
        public async Task<ActionResult< IEnumerable<TodoReadDto>>> GetAllTodo()
        {
            var query = new GetAllTodoRequest();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        #endregion

        #region GetById: /todo/5
        [HttpGet("{id}", Name = "GetTodoById")]
        public async Task< ActionResult<TodoReadDto>> GetTodoById(int id)
        {
            var query = new GetTodoByIdRequest(id);
            var result = await _mediator.Send(query);
            return result != null ? (ActionResult)Ok(result) : NotFound();
            
        }
        #endregion

        #region POST: /todo
        [HttpPost]
        public async Task< ActionResult<TodoReadDto>> CreateTodo(CreateTodoRequest dataDto)
        {
           
            var result = await _mediator.Send(dataDto);
            
            return result != null ? (ActionResult) CreatedAtAction(nameof(GetTodoById), new { Id = result.Id }, result) : BadRequest();
            
        }
        #endregion

        #region PUT: /todo/5
        [HttpPut("{id}")]
        public async Task <ActionResult> UpdateTodo(int id, TodoUpdateDto dataDto)
        {
            var result = await _mediator.Send(new UpdateTodoRequest(id, dataDto));
            return result != null ? (ActionResult)NoContent():NotFound();
          
        }
        #endregion

        #region PATCH: /todo/5
        [HttpPatch("{id}")]
        public async Task< ActionResult> PatchTodo(int id, JsonPatchDocument<TodoUpdateDto> pathDoc) 
        {
            var resultFromRepo = await _mediator.Send(new PatchTodoRequest(id,null));
            if (resultFromRepo == null)
            {
                return NotFound();
            }
            var toPatch =  resultFromRepo;
            pathDoc.ApplyTo(toPatch, ModelState);
            if (!TryValidateModel(toPatch))
            {
                return ValidationProblem(ModelState);
            }
            var saveResult = await _mediator.Send(new PatchTodoRequest(id, toPatch));


            return NoContent();
            /*
             ----> sample format
            [
                {
                    "op": "replace",
                    "path": "/description",
                    "value": "this is patch"
                }
            ]
            */
        }
        #endregion

        #region DELETE: /todo/5
        [HttpDelete("{id}")]
        public async Task< ActionResult> DeleteTodo(int id)
        {
            var result = await _mediator.Send(new DeleteTodoRequest(id));
            return result != null ? (ActionResult)NoContent() : NotFound();
           
        }
        #endregion
    }
}
