
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;
using ProjectArti.Api.Model;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestClientsController : ControllerBase
    {
        private readonly My_dbContext _context;

        public RequestClientsController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/RequestClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestClient>>> GetrequestClients()
        {
            return await _context.requestClients.ToListAsync();
        }

        // GET: api/RequestClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestClient>> GetRequestClient(int id)
        {
            var requestClient = await _context.requestClients.FindAsync(id);

            if (requestClient == null)
            {
                return NotFound();
            }

            return requestClient;
        }

        // PUT: api/RequestClients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestClient(int id, RequestClient requestClient)
        {
            if (id != requestClient.id)
            {
                return BadRequest();
            }

            _context.Entry(requestClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestClientExists(id))
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

        // POST: api/RequestClients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequestClient>> PostRequestClient(RequestClient requestClient)
        {
            _context.requestClients.Add(requestClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestClient", new { id = requestClient.id }, requestClient);
        }

        // DELETE: api/RequestClients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestClient(int id)
        {
            var requestClient = await _context.requestClients.FindAsync(id);
            if (requestClient == null)
            {
                return NotFound();
            }

            _context.requestClients.Remove(requestClient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestClientExists(int id)
        {
            return _context.requestClients.Any(e => e.id == id);
        }
    }
}
