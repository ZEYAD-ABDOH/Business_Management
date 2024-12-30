
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwimmingPoolTsController : ControllerBase
    {
        private readonly My_dbContext _context;

        public SwimmingPoolTsController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/SwimmingPoolTs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SwimmingPoolT>>> GetSwimmingPoolT()
        {
            return await _context.SwimmingPoolT.ToListAsync();
        }

        // GET: api/SwimmingPoolTs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SwimmingPoolT>> GetSwimmingPoolT(int id)
        {
            var swimmingPoolT = await _context.SwimmingPoolT.FindAsync(id);

            if (swimmingPoolT == null)
            {
                return NotFound();
            }

            return swimmingPoolT;
        }

        // PUT: api/SwimmingPoolTs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSwimmingPoolT(int id, SwimmingPoolT swimmingPoolT)
        {
            if (id != swimmingPoolT.Id)
            {
                return BadRequest();
            }

            _context.Entry(swimmingPoolT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SwimmingPoolTExists(id))
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

        // POST: api/SwimmingPoolTs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SwimmingPoolT>> PostSwimmingPoolT(SwimmingPoolT swimmingPoolT)
        {
            _context.SwimmingPoolT.Add(swimmingPoolT);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSwimmingPoolT", new { id = swimmingPoolT.Id }, swimmingPoolT);
        }

        // DELETE: api/SwimmingPoolTs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSwimmingPoolT(int id)
        {
            var swimmingPoolT = await _context.SwimmingPoolT.FindAsync(id);
            if (swimmingPoolT == null)
            {
                return NotFound();
            }

            _context.SwimmingPoolT.Remove(swimmingPoolT);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SwimmingPoolTExists(int id)
        {
            return _context.SwimmingPoolT.Any(e => e.Id == id);
        }
    }
}
