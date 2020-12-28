using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.DTOs;
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
        // GET: api/<TodoController>
        [HttpGet]
        public ActionResult< IEnumerable<TodoReadDto>> Get()
        {
            //var data = new TodoDto
            //{
            //    Id = 0,
            //    Name = "my name",
            //    Description = "description"
            //};
            todoList.Add(new TodoReadDto
            {
                Id = 1,
                Name = "name1",
                Description = "description1"

                
            });
            todoList.Add(new TodoReadDto
            {
                Id = 2,
                Name = "name2",
                Description = "description2"

            });


            return Ok(todoList);
        }

        //GET api/<TodoController>/5
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult <TodoReadDto> GetById(int id)
        {
            todoList.Add(new TodoReadDto
            {
                Id = 3,
                Name = "name2",
                Description = "description2"

            });
            return Ok(todoList);
        }

        // POST api/<TodoController>
        [HttpPost]
        public ActionResult<TodoReadDto> Add(TodoCommandDto data)
        {
            var listdto = new TodoReadDto
            {
                Id = 3 ,
                Name = data.Name,
                Description = data.Description

            };

            if (data != null)
            {
                //todoList.Add(data);
                return CreatedAtRoute(nameof(GetById), new { Id = listdto.Id, listdto });
                //return Ok(todoList); 
            }
            return NotFound();
        }

        //PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public ActionResult UpdateTodo(int id, TodoCommandDto updateCommandDto)
        {
            //var result = repository.GetDatabyId(id);
            //if (result == null) { return NotFound(); }

            //repository.Update(updateCommandDto);
            //save();

            return NoContent();
        }

        //// DELETE api/<TodoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
