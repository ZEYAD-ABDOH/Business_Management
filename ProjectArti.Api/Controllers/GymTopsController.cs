
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;
using ProjectArti.Api.Model;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymTopsController : ControllerBase
    {
        private readonly My_dbContext _context;

        public GymTopsController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/GymTops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymTop>>> GetGymTop()
        {
            return await _context.GymTop.ToListAsync();
        }

        // GET: api/GymTops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GymTop>> GetGymTop(int id)
        {
            var gymTop = await _context.GymTop.FindAsync(id);

            if (gymTop == null)
            {
                return NotFound();
            }

            return gymTop;
        }

        // PUT: api/GymTops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGymTop(int id, GymTop gymTop)
        {
            if (id != gymTop.Id)
            {
                return BadRequest();
            }

            _context.Entry(gymTop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GymTopExists(id))
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

        // POST: api/GymTops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GymTop>> PostGymTop(GymTop gymTop)
        {
            _context.GymTop.Add(gymTop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGymTop", new { id = gymTop.Id }, gymTop);
        }

        // DELETE: api/GymTops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGymTop(int id)
        {
            var gymTop = await _context.GymTop.FindAsync(id);
            if (gymTop == null)
            {
                return NotFound();
            }

            _context.GymTop.Remove(gymTop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GymTopExists(int id)
        {
            return _context.GymTop.Any(e => e.Id == id);
        }
    }
}
