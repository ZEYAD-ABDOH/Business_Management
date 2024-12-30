
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalconiesController : ControllerBase
    {
        private readonly My_dbContext _context;

        public BalconiesController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/Balconies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Balcony>>> GetBalcony()
        {
            return await _context.Balcony.ToListAsync();
        }

        // GET: api/Balconies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Balcony>> GetBalcony(int id)
        {
            var balcony = await _context.Balcony.FindAsync(id);

            if (balcony == null)
            {
                return NotFound();
            }

            return balcony;
        }

        // PUT: api/Balconies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBalcony(int id, Balcony balcony)
        {
            if (id != balcony.Id)
            {
                return BadRequest();
            }

            _context.Entry(balcony).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BalconyExists(id))
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

        // POST: api/Balconies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Balcony>> PostBalcony(Balcony balcony)
        {
            _context.Balcony.Add(balcony);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBalcony", new { id = balcony.Id }, balcony);
        }

        // DELETE: api/Balconies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBalcony(int id)
        {
            var balcony = await _context.Balcony.FindAsync(id);
            if (balcony == null)
            {
                return NotFound();
            }

            _context.Balcony.Remove(balcony);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BalconyExists(int id)
        {
            return _context.Balcony.Any(e => e.Id == id);
        }
    }
}
