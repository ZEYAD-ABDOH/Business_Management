
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentedStatusController : ControllerBase
    {
        private readonly My_dbContext _context;

        public RentedStatusController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/RentedStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentedStatus>>> GetRentedStatus()
        {
            return await _context.RentedStatus.ToListAsync();
        }

        // GET: api/RentedStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentedStatus>> GetRentedStatus(int id)
        {
            var rentedStatus = await _context.RentedStatus.FindAsync(id);

            if (rentedStatus == null)
            {
                return NotFound();
            }

            return rentedStatus;
        }

        // PUT: api/RentedStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentedStatus(int id, RentedStatus rentedStatus)
        {
            if (id != rentedStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(rentedStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentedStatusExists(id))
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

        // POST: api/RentedStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RentedStatus>> PostRentedStatus(RentedStatus rentedStatus)
        {
            _context.RentedStatus.Add(rentedStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRentedStatus", new { id = rentedStatus.Id }, rentedStatus);
        }

        // DELETE: api/RentedStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentedStatus(int id)
        {
            var rentedStatus = await _context.RentedStatus.FindAsync(id);
            if (rentedStatus == null)
            {
                return NotFound();
            }

            _context.RentedStatus.Remove(rentedStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentedStatusExists(int id)
        {
            return _context.RentedStatus.Any(e => e.Id == id);
        }
    }
}
