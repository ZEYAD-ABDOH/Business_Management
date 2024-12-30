
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommercialTypesController : ControllerBase
    {
        private readonly My_dbContext _context;

        public CommercialTypesController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/CommercialTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommercialType>>> GetCommercialType()
        {
            return await _context.CommercialType.ToListAsync();
        }

        // GET: api/CommercialTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommercialType>> GetCommercialType(int id)
        {
            var commercialType = await _context.CommercialType.FindAsync(id);

            if (commercialType == null)
            {
                return NotFound();
            }

            return commercialType;
        }

        // PUT: api/CommercialTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommercialType(int id, CommercialType commercialType)
        {
            if (id != commercialType.Id)
            {
                return BadRequest();
            }

            _context.Entry(commercialType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommercialTypeExists(id))
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

        // POST: api/CommercialTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommercialType>> PostCommercialType(CommercialType commercialType)
        {
            _context.CommercialType.Add(commercialType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommercialType", new { id = commercialType.Id }, commercialType);
        }

        // DELETE: api/CommercialTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommercialType(int id)
        {
            var commercialType = await _context.CommercialType.FindAsync(id);
            if (commercialType == null)
            {
                return NotFound();
            }

            _context.CommercialType.Remove(commercialType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommercialTypeExists(int id)
        {
            return _context.CommercialType.Any(e => e.Id == id);
        }
    }
}
