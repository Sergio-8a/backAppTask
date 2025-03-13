using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTask.Context;
using WebApiTask.Models;

namespace WebApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskManagersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TaskManagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskManager>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/TaskManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskManager>> GetTaskManager(int id)
        {
            var taskManager = await _context.Tasks.FindAsync(id);

            if (taskManager == null)
            {
                return NotFound();
            }

            return taskManager;
        }

        // PUT: api/TaskManagers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskManager(int id, TaskManager taskManager)
        {
            if (id != taskManager.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskManagerExists(id))
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

        // POST: api/TaskManagers
        [HttpPost]
        public async Task<ActionResult<TaskManager>> PostTaskManager(TaskManager taskManager)
        {
            _context.Tasks.Add(taskManager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskManager", new { id = taskManager.Id }, taskManager);
        }

        // DELETE: api/TaskManagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskManager(int id)
        {
            var taskManager = await _context.Tasks.FindAsync(id);
            if (taskManager == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(taskManager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskManagerExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
