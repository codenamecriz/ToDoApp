﻿
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Data;
using TodoApp.API.DTOs;
using TodoApp.API.DTOs.Todo;
using TodoApp.API.Handlers.Commands.Todos.Delete;
using TodoApp.API.Handlers.Commands.Todos.Put;
using TodoApp.API.Handlers.Commands.Todos.Update;
using TodoApp.API.Models;
using TodoApp.API.Services.Commands.Todos.Create;
using TodoApp.API.Services.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApp.API.Controllers  // API Controller
{
    //[Route("/[controller]")] //----> route for generic
    [Route("todo")] //----------> route for specific
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

            //if (dataDto != null)
            //{
            //    var todoModel = _mapper.Map<Todo>(dataDto);
            //    _todoRepo.CreateTodo(todoModel);
            //    _todoRepo.SaveChanges();
            //    var todoReadDto = _mapper.Map<TodoReadDto>(todoModel);
            //    return CreatedAtRoute(nameof(GetTodoById), new { Id = todoReadDto.Id }, todoReadDto ); 
               
            //}
            //return NotFound();
        }
        #endregion

        #region PUT: /todo/5
        [HttpPut("{id}")]
        public async Task <ActionResult> UpdateTodo(int id, TodoUpdateDto dataDto)
        {
            var result = await _mediator.Send(new UpdateTodoRequest(id, dataDto));//.Name, dataDto.Description));
            return result != null ? (ActionResult)NoContent():NotFound();
            //var dataFromRepo = _todoRepo.GetTodoById(id);
            //if (dataFromRepo != null)
            //{
            //    _mapper.Map(dataDto, dataFromRepo);
            //    _todoRepo.UpdateTodo(dataFromRepo);
            //    _todoRepo.SaveChanges();
            //    return NoContent();
            //}
            //return NotFound();
        }
        #endregion

        #region PATCH: /todo/5
        [HttpPatch("{id}")]
        public async Task< ActionResult> PatchTodo(int id, JsonPatchDocument<TodoUpdateDto> pathDoc) //------------- Target the espisific filed to update
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
            //var todoFromRepo = _todoRepo.GetTodoById(id);
            //if (todoFromRepo != null)
            //{
            //    var todoToPatch = _mapper.Map<TodoUpdateDto>(todoFromRepo);
            //    pathDoc.ApplyTo(todoToPatch, ModelState);

            //    if (!TryValidateModel(todoToPatch))
            //    {
            //        return ValidationProblem(ModelState);
            //    }
            //    _mapper.Map(todoToPatch, todoFromRepo);
            //    _todoRepo.UpdateTodo(todoFromRepo);
            //    _todoRepo.SaveChanges();
            //    return NoContent();
            //}
            //return NotFound();
            // ----> sample format
            //[
            //    {
            //        "op": "replace",
            //        "path": "/description",
            //        "value": "this is patch"
            //    }
            //]
        }
        #endregion

        #region DELETE: /todo/5
        [HttpDelete("{id}")]
        public async Task< ActionResult> DeleteTodo(int id)
        {
            var result = await _mediator.Send(new DeleteTodoRequest(id));
            return result != null ? (ActionResult)NoContent() : NotFound();
            //var todoFromRepo = _todoRepo.GetTodoById(id);
            //if (todoFromRepo != null)
            //{
            //    _todoRepo.DeleteTodo(todoFromRepo);
            //    _todoRepo.SaveChanges();
            //    return NoContent();
            //}
            //return NotFound();
        }
        #endregion
    }
}
