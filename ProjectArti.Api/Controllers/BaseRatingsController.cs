
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;
using ProjectArti.Api.Model;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseRatingsController : ControllerBase
    {
        private readonly My_dbContext _context;

        public BaseRatingsController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/BaseRatings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseRating>>> GetBaseRating()
        {
            return await _context.BaseRating.ToListAsync();
        }

        // GET: api/BaseRatings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseRating>> GetBaseRating(int id)
        {
            var baseRating = await _context.BaseRating.FindAsync(id);

            if (baseRating == null)
            {
                return NotFound();
            }

            return baseRating;
        }

        // PUT: api/BaseRatings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaseRating(int id, BaseRating baseRating)
        {
            if (id != baseRating.Id)
            {
                return BadRequest();
            }

            _context.Entry(baseRating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseRatingExists(id))
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

        // POST: api/BaseRatings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BaseRating>> PostBaseRating(BaseRating baseRating)
        {
            _context.BaseRating.Add(baseRating);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaseRating", new { id = baseRating.Id }, baseRating);
        }

        // DELETE: api/BaseRatings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBaseRating(int id)
        {
            var baseRating = await _context.BaseRating.FindAsync(id);
            if (baseRating == null)
            {
                return NotFound();
            }

            _context.BaseRating.Remove(baseRating);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaseRatingExists(int id)
        {
            return _context.BaseRating.Any(e => e.Id == id);
        }
    }
}
