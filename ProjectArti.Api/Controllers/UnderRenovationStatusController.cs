
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnderRenovationStatusController : ControllerBase
    {
        private readonly My_dbContext _context;

        public UnderRenovationStatusController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/UnderRenovationStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnderRenovationStatus>>> GetUnderRenovationStatus()
        {
            return await _context.UnderRenovationStatus.ToListAsync();
        }

        // GET: api/UnderRenovationStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnderRenovationStatus>> GetUnderRenovationStatus(int id)
        {
            var underRenovationStatus = await _context.UnderRenovationStatus.FindAsync(id);

            if (underRenovationStatus == null)
            {
                return NotFound();
            }

            return underRenovationStatus;
        }

        // PUT: api/UnderRenovationStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnderRenovationStatus(int id, UnderRenovationStatus underRenovationStatus)
        {
            if (id != underRenovationStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(underRenovationStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnderRenovationStatusExists(id))
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

        // POST: api/UnderRenovationStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnderRenovationStatus>> PostUnderRenovationStatus(UnderRenovationStatus underRenovationStatus)
        {
            _context.UnderRenovationStatus.Add(underRenovationStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnderRenovationStatus", new { id = underRenovationStatus.Id }, underRenovationStatus);
        }

        // DELETE: api/UnderRenovationStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnderRenovationStatus(int id)
        {
            var underRenovationStatus = await _context.UnderRenovationStatus.FindAsync(id);
            if (underRenovationStatus == null)
            {
                return NotFound();
            }

            _context.UnderRenovationStatus.Remove(underRenovationStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnderRenovationStatusExists(int id)
        {
            return _context.UnderRenovationStatus.Any(e => e.Id == id);
        }
    }
}
