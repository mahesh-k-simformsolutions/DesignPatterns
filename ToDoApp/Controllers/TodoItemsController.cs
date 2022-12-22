using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todoes.Models;
using Todoes.Repository;

namespace Todoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly IRepoData _repo;
        public TodoItemsController(TodoContext context,IRepoData repo)
        {
            _context = context;
            _repo = repo;
        }
        // GET: api/TodoItems
        [HttpGet]
        public Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
           return  _repo.Get();
        }
        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var todoItem = await _repo.Get(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
        // PUT: api/TodoItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }
             await _repo.Put(todoItem);
            return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            await _repo.Post(todoItem);
            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        }
        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(int id)
        {
            
            return await _repo.Delete(id);
        }
    }
}
