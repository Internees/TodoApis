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
            Console.WriteLine($"Received Task: {todoTask.Title}, {todoTask.Description}, Status: {todoTask.Status}");

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

        // GET: Todo/Lists
        [HttpGet("Lists")]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodos()
        {
            return await _context.Lists.ToListAsync();
        }

        // GET: Todo/Lists/5
        [HttpGet("Lists/{id}")]
        public async Task<ActionResult<TodoList>> GetTodoList(int id)
        {
            var todoList = await _context.Lists.FindAsync(id);

            if (todoList == null)
            {
                return NotFound();
            }

            return todoList;
        }

        // PUT: Todo/Lists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Lists/{id}")]
        public async Task<IActionResult> PutTodoList(int id, TodoList todoList)
        {
            if (id != todoList.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoListExists(id))
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

        // POST: Todo/Lists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Lists")]
        public async Task<ActionResult<TodoList>> PostTodoList(TodoList todoList)
        {
            _context.Lists.Add(todoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoList", new { id = todoList.Id }, todoList);
        }

        // DELETE: Todo/Lists/5
        [HttpDelete("Lists/{id}")]
        public async Task<IActionResult> DeleteTodoList(int id)
        {
            var todoList = await _context.Lists.FindAsync(id);
            if (todoList == null)
            {
                return NotFound();
            }

            _context.Lists.Remove(todoList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoListExists(int id)
        {
            return _context.Lists.Any(e => e.Id == id);
        }

    }
}
