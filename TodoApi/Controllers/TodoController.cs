using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Interfaces;
using TodoApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var todo = _repository.Get(id);
            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        // GET api/<TodoController>/5
        [HttpGet]
        public ActionResult<List<TodoItem>> Get()
        {
            var todos = _repository.GetAll();
            return Ok(todos);
        }


        // POST api/<TodoController>
        [HttpPost]
        public ActionResult Post([FromBody] TodoItem value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _repository.Add(value);

            return Created("api/todo", value);
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TodoItem value)
        {
            var todo = _repository.Get(id);
            if (todo == null)
            {
                return BadRequest();
            }

            _repository.Update(value);
            return NoContent();
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var todo = _repository.Get(id);
            if (todo == null)
            {
                return BadRequest();
            }

            _repository.Delete(todo);
            return NoContent();
        }
    }
}