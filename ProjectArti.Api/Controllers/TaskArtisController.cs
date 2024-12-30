using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;
using ProjectArti.Api.Model;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskArtisController : ControllerBase
    {
        private readonly My_dbContext _context;

        public TaskArtisController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/TaskArtis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskArti>>> GettaskArtis()
        {
            return await _context.taskArtis.ToListAsync();
        }

        // GET: api/TaskArtis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskArti>> GetTaskArti(int id)
        {
            var taskArti = await _context.taskArtis.FindAsync(id);

            if (taskArti == null)
            {
                return NotFound();
            }

            return taskArti;
        }

        // PUT: api/TaskArtis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskArti(int id, TaskArti taskArti)
        {
            if (id != taskArti.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskArti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskArtiExists(id))
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

        // POST: api/TaskArtis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskArti>> PostTaskArti(TaskArti taskArti)
        {
            _context.taskArtis.Add(taskArti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskArti", new { id = taskArti.Id }, taskArti);
        }

        // DELETE: api/TaskArtis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskArti(int id)
        {
            var taskArti = await _context.taskArtis.FindAsync(id);
            if (taskArti == null)
            {
                return NotFound();
            }

            _context.taskArtis.Remove(taskArti);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskArtiExists(int id)
        {
            return _context.taskArtis.Any(e => e.Id == id);
        }
    }
}
