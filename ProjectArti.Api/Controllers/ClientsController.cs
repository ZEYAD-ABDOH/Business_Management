
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;
using ProjectArti.Api.Model;
using ProjectArti.Api.Service;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly My_dbContext _context;
        private readonly IGetToken _getToken;

        public ClientsController(My_dbContext context  , IGetToken getToken)
        {
            _context = context;
            _getToken = getToken;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Getclients()
        {
            return await _context.clients.ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }
        [HttpPost("Login")]

        public async Task<IActionResult> login ([FromBody] Userlogin userlogin)
        {
            if (string.IsNullOrWhiteSpace(userlogin.Name)|| string.IsNullOrWhiteSpace(userlogin.Password))
            {
                return BadRequest();
            }

            var userLogion = await _context.clients.SingleOrDefaultAsync(u => u.Name == userlogin.Name && u.Password == userlogin.Password);
            if (userLogion == null)
            {
                return Unauthorized("اسم المستخدام او كلمة المرور ");
            }

            string role;

            if (userLogion.Role == 1)
            {
                role = "Admin";
            }

            else if (userLogion.Role == 2)
            {
                role = "User";
            }
            else if (userLogion.Role == 3)
            {
                role = "Craftsman";
            }
            else if (userLogion.Role == 4)
            {
                role = "Employee";
            }
            else
            {
                return BadRequest("الصلاحية غير معروف");
            }
            // طباعة للمستخدم 
            var token = _getToken.CreateToken(userlogin.Name,role);
           
           
                return Ok(new {
                    Message = " تم التسجيل  ",
                    token = token,
                    role= role

                
                });
           
        }



        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return _context.clients.Any(e => e.Id == id);
        }
    }
}
