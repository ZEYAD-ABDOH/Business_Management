
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorTypesController : ControllerBase
    {
        private readonly My_dbContext _context;

        public FloorTypesController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/FloorTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FloorType>>> GetFloorType()
        {
            return await _context.FloorType.ToListAsync();
        }

        // GET: api/FloorTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FloorType>> GetFloorType(int id)
        {
            var floorType = await _context.FloorType.FindAsync(id);

            if (floorType == null)
            {
                return NotFound();
            }

            return floorType;
        }

        // PUT: api/FloorTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFloorType(int id, FloorType floorType)
        {
            if (id != floorType.Id)
            {
                return BadRequest();
            }

            _context.Entry(floorType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FloorTypeExists(id))
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

        // POST: api/FloorTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FloorType>> PostFloorType(FloorType floorType)
        {
            _context.FloorType.Add(floorType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFloorType", new { id = floorType.Id }, floorType);
        }

        // DELETE: api/FloorTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFloorType(int id)
        {
            var floorType = await _context.FloorType.FindAsync(id);
            if (floorType == null)
            {
                return NotFound();
            }

            _context.FloorType.Remove(floorType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FloorTypeExists(int id)
        {
            return _context.FloorType.Any(e => e.Id == id);
        }
    }
}
