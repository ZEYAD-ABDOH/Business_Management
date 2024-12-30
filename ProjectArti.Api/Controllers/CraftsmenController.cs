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
    public class CraftsmenController : ControllerBase
    {
        private readonly My_dbContext _context;

        public CraftsmenController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/Craftsmen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Craftsman>>> Getcraftsmens()
        {
            return await _context.craftsmens.ToListAsync();
        }

        // GET: api/Craftsmen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Craftsman>> GetCraftsman(int id)
        {
            var craftsman = await _context.craftsmens.FindAsync(id);

            if (craftsman == null)
            {
                return NotFound();
            }

            return craftsman;
        }

        // PUT: api/Craftsmen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCraftsman(int id, Craftsman craftsman)
        {
            if (id != craftsman.Id)
            {
                return BadRequest();
            }

            _context.Entry(craftsman).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CraftsmanExists(id))
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

        // POST: api/Craftsmen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Craftsman>> PostCraftsman(Craftsman craftsman)
        {
            _context.craftsmens.Add(craftsman);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCraftsman", new { id = craftsman.Id }, craftsman);
        }

        // DELETE: api/Craftsmen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCraftsman(int id)
        {
            var craftsman = await _context.craftsmens.FindAsync(id);
            if (craftsman == null)
            {
                return NotFound();
            }

            _context.craftsmens.Remove(craftsman);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CraftsmanExists(int id)
        {
            return _context.craftsmens.Any(e => e.Id == id);
        }
    }
}
