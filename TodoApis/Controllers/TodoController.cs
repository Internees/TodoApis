using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApis.Context;
using TodoApis.Model;

namespace TodoApis.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        // GET:/Todo/Tasks
        [HttpGet]
        [HttpGet("Tasks")]
        public async Task<ActionResult<IEnumerable<TodoTask>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: /Todo/Tasks/5
        [HttpGet("Tasks/{id}")]
        public async Task<ActionResult<TodoTask>> GetTodoTask(int id)
        {
            var todoTask = await _context.Tasks.FindAsync(id);

            if (todoTask == null)
            {
                return NotFound();
            }

            return todoTask;
        }

        // PUT: /Todo/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Tasks/{id}")]
        public async Task<IActionResult> PutTodoTask(int id, TodoTask todoTask)
        {
            if (id != todoTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoTaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: /Todo/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Tasks")]
        public async Task<ActionResult<TodoTask>> PostTodoTask(TodoTask todoTask)
        {
            _context.Tasks.Add(todoTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoTask", new { id = todoTask.Id }, todoTask);
        }

        // DELETE: /Todo/Tasks/5
        [HttpDelete("Tasks/{id}")]
        public async Task<IActionResult> DeleteTodoTask(int id)
        {
            var todoTask = await _context.Tasks.FindAsync(id);
            if (todoTask == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(todoTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoTaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
