
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableStatusController : ControllerBase
    {
        private readonly My_dbContext _context;

        public AvailableStatusController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/AvailableStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvailableStatus>>> GetAvailableStatus()
        {
            return await _context.AvailableStatus.ToListAsync();
        }

        // GET: api/AvailableStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvailableStatus>> GetAvailableStatus(int id)
        {
            var availableStatus = await _context.AvailableStatus.FindAsync(id);

            if (availableStatus == null)
            {
                return NotFound();
            }

            return availableStatus;
        }

        // PUT: api/AvailableStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvailableStatus(int id, AvailableStatus availableStatus)
        {
            if (id != availableStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(availableStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvailableStatusExists(id))
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

        // POST: api/AvailableStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AvailableStatus>> PostAvailableStatus(AvailableStatus availableStatus)
        {
            _context.AvailableStatus.Add(availableStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvailableStatus", new { id = availableStatus.Id }, availableStatus);
        }

        // DELETE: api/AvailableStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvailableStatus(int id)
        {
            var availableStatus = await _context.AvailableStatus.FindAsync(id);
            if (availableStatus == null)
            {
                return NotFound();
            }

            _context.AvailableStatus.Remove(availableStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvailableStatusExists(int id)
        {
            return _context.AvailableStatus.Any(e => e.Id == id);
        }
    }
}
