using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardenTypesController : ControllerBase
    {
        private readonly My_dbContext _context;

        public GardenTypesController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/GardenTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GardenType>>> GetGardenType()
        {
            return await _context.GardenType.ToListAsync();
        }

        // GET: api/GardenTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GardenType>> GetGardenType(int id)
        {
            var gardenType = await _context.GardenType.FindAsync(id);

            if (gardenType == null)
            {
                return NotFound();
            }

            return gardenType;
        }

        // PUT: api/GardenTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGardenType(int id, GardenType gardenType)
        {
            if (id != gardenType.Id)
            {
                return BadRequest();
            }

            _context.Entry(gardenType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GardenTypeExists(id))
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

        // POST: api/GardenTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GardenType>> PostGardenType(GardenType gardenType)
        {
            _context.GardenType.Add(gardenType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGardenType", new { id = gardenType.Id }, gardenType);
        }

        // DELETE: api/GardenTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGardenType(int id)
        {
            var gardenType = await _context.GardenType.FindAsync(id);
            if (gardenType == null)
            {
                return NotFound();
            }

            _context.GardenType.Remove(gardenType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GardenTypeExists(int id)
        {
            return _context.GardenType.Any(e => e.Id == id);
        }
    }
}
