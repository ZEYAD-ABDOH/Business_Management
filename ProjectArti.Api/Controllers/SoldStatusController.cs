
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldStatusController : ControllerBase
    {
        private readonly My_dbContext _context;

        public SoldStatusController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/SoldStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoldStatus>>> GetSoldStatus()
        {
            return await _context.SoldStatus.ToListAsync();
        }

        // GET: api/SoldStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoldStatus>> GetSoldStatus(int id)
        {
            var soldStatus = await _context.SoldStatus.FindAsync(id);

            if (soldStatus == null)
            {
                return NotFound();
            }

            return soldStatus;
        }

        // PUT: api/SoldStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoldStatus(int id, SoldStatus soldStatus)
        {
            if (id != soldStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(soldStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoldStatusExists(id))
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

        // POST: api/SoldStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SoldStatus>> PostSoldStatus(SoldStatus soldStatus)
        {
            _context.SoldStatus.Add(soldStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoldStatus", new { id = soldStatus.Id }, soldStatus);
        }

        // DELETE: api/SoldStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoldStatus(int id)
        {
            var soldStatus = await _context.SoldStatus.FindAsync(id);
            if (soldStatus == null)
            {
                return NotFound();
            }

            _context.SoldStatus.Remove(soldStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoldStatusExists(int id)
        {
            return _context.SoldStatus.Any(e => e.Id == id);
        }
    }
}
