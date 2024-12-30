
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecreationalAreasController : ControllerBase
    {
        private readonly My_dbContext _context;

        public RecreationalAreasController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/RecreationalAreas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecreationalArea>>> GetRecreationalArea()
        {
            return await _context.RecreationalArea.ToListAsync();
        }

        // GET: api/RecreationalAreas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecreationalArea>> GetRecreationalArea(int id)
        {
            var recreationalArea = await _context.RecreationalArea.FindAsync(id);

            if (recreationalArea == null)
            {
                return NotFound();
            }

            return recreationalArea;
        }

        // PUT: api/RecreationalAreas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecreationalArea(int id, RecreationalArea recreationalArea)
        {
            if (id != recreationalArea.Id)
            {
                return BadRequest();
            }

            _context.Entry(recreationalArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecreationalAreaExists(id))
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

        // POST: api/RecreationalAreas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecreationalArea>> PostRecreationalArea(RecreationalArea recreationalArea)
        {
            _context.RecreationalArea.Add(recreationalArea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecreationalArea", new { id = recreationalArea.Id }, recreationalArea);
        }

        // DELETE: api/RecreationalAreas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecreationalArea(int id)
        {
            var recreationalArea = await _context.RecreationalArea.FindAsync(id);
            if (recreationalArea == null)
            {
                return NotFound();
            }

            _context.RecreationalArea.Remove(recreationalArea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecreationalAreaExists(int id)
        {
            return _context.RecreationalArea.Any(e => e.Id == id);
        }
    }
}
