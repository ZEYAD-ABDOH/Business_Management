
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;
using ProjectArti.Api.Model;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequireRoleUser")]
    public class BusinessTypesController : ControllerBase
    {
        private readonly My_dbContext _context;

        public BusinessTypesController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/BusinessTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessType>>> GetBusinessType()
        {
            return await _context.BusinessType.ToListAsync();
        }

        // GET: api/BusinessTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessType>> GetBusinessType(int id)
        {
            var businessType = await _context.BusinessType.FindAsync(id);

            if (businessType == null)
            {
                return NotFound();
            }

            return businessType;
        }

        // PUT: api/BusinessTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessType(int id, BusinessType businessType)
        {
            if (id != businessType.Id)
            {
                return BadRequest();
            }

            _context.Entry(businessType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessTypeExists(id))
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

        // POST: api/BusinessTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusinessType>> PostBusinessType(BusinessType businessType)
        {
            _context.BusinessType.Add(businessType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessType", new { id = businessType.Id }, businessType);
        }

        // DELETE: api/BusinessTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessType(int id)
        {
            var businessType = await _context.BusinessType.FindAsync(id);
            if (businessType == null)
            {
                return NotFound();
            }

            _context.BusinessType.Remove(businessType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusinessTypeExists(int id)
        {
            return _context.BusinessType.Any(e => e.Id == id);
        }
    }
}
