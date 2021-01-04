using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Data;
using TodoApp.API.DTOs;
using TodoApp.API.DTOs.Todo;
using TodoApp.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApp.API.Controllers  // API Controller
{
    //[Route("api/[controller]")] //----> route for generic
    [Route("api/todo")] //----------> route for specific
    [ApiController]
    public class TodoController : ControllerBase
    {
      
         List<TodoReadDto> todoList = new List<TodoReadDto>();
        private readonly ITodoRepository todoRepo;
        private readonly IMapper mapper;

        public TodoController(ITodoRepository _todoRepo,IMapper _mapper)
        {
            todoRepo = _todoRepo;
            mapper = _mapper;
        }
        // GET: api/<TodoController>
        [HttpGet]
        public ActionResult< IEnumerable<TodoReadDto>> GetList()
        {
        
            var todoData = todoRepo.GetList();
            return Ok(mapper.Map < IEnumerable<TodoReadDto>>(todoData));
        }

        //GET api/<TodoController>/5
        [HttpGet("{id}", Name = "GetListById")]
        public ActionResult<TodoReadDto> GetListById(int id)
        {
            var todoData = todoRepo.GetListById(id);
            if (todoData != null)
            {
                return Ok(mapper.Map<TodoReadDto>(todoData));
            }
            return NotFound();
        }

        // POST api/<TodoController>
        [HttpPost]
        public ActionResult<TodoReadDto> CreateTodo(TodoCreateDto dataDto)
        {
            if (dataDto != null)
            {
                var todoModel = mapper.Map<Todo>(dataDto);
                todoRepo.CreateTodo(todoModel);
                todoRepo.SaveChanges();
                var todoReadDto = mapper.Map<TodoReadDto>(todoModel);
                return CreatedAtRoute(nameof(GetListById), new { Id = todoReadDto.Id }, todoReadDto ); 
               
            }
            return NotFound();
        }

        //PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public ActionResult UpdateTodo(int id, TodoUpdateDto dataDto)
        {
            var dataFromRepo = todoRepo.GetListById(id);
            if (dataFromRepo != null)
            {
                mapper.Map(dataDto, dataFromRepo);
                todoRepo.UpdateTodo(dataFromRepo);
                todoRepo.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
        //PATCH api/todo/5
        [HttpPatch("{id}")]
        public ActionResult PartialTodoUpdate(int id, JsonPatchDocument<TodoUpdateDto> pathDoc) //------------- Target the espisific filed to update
        {
            var todoFromRepo = todoRepo.GetListById(id);
            if (todoFromRepo != null)
            {
                var todoToPatch = mapper.Map<TodoUpdateDto>(todoFromRepo);
                pathDoc.ApplyTo(todoToPatch, ModelState);

                if (!TryValidateModel(todoToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                mapper.Map(todoToPatch, todoFromRepo);
                todoRepo.UpdateTodo(todoFromRepo);
                todoRepo.SaveChanges();
                return NoContent();
            }
            return NotFound();
            // ----> sample format
            //[
            //    {
            //        "op": "replace",
            //        "path": "/description",
            //        "value": "this is patch"
            //    }
            //]
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(int id)
        {
            var todoFromRepo = todoRepo.GetListById(id);
            if (todoFromRepo != null)
            {
                todoRepo.DeleteTodo(todoFromRepo);
                todoRepo.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
    }
}
