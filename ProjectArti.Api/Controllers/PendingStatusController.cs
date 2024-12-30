
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendingStatusController : ControllerBase
    {
        private readonly My_dbContext _context;

        public PendingStatusController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/PendingStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PendingStatus>>> GetPendingStatus()
        {
            return await _context.PendingStatus.ToListAsync();
        }

        // GET: api/PendingStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PendingStatus>> GetPendingStatus(int id)
        {
            var pendingStatus = await _context.PendingStatus.FindAsync(id);

            if (pendingStatus == null)
            {
                return NotFound();
            }

            return pendingStatus;
        }

        // PUT: api/PendingStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPendingStatus(int id, PendingStatus pendingStatus)
        {
            if (id != pendingStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(pendingStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PendingStatusExists(id))
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

        // POST: api/PendingStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PendingStatus>> PostPendingStatus(PendingStatus pendingStatus)
        {
            _context.PendingStatus.Add(pendingStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPendingStatus", new { id = pendingStatus.Id }, pendingStatus);
        }

        // DELETE: api/PendingStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePendingStatus(int id)
        {
            var pendingStatus = await _context.PendingStatus.FindAsync(id);
            if (pendingStatus == null)
            {
                return NotFound();
            }

            _context.PendingStatus.Remove(pendingStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PendingStatusExists(int id)
        {
            return _context.PendingStatus.Any(e => e.Id == id);
        }
    }
}
