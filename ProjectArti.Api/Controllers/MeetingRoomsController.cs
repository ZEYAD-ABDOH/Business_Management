
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomsController : ControllerBase
    {
        private readonly My_dbContext _context;

        public MeetingRoomsController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/MeetingRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingRoom>>> GetMeetingRoom()
        {
            return await _context.MeetingRoom.ToListAsync();
        }

        // GET: api/MeetingRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingRoom>> GetMeetingRoom(int id)
        {
            var meetingRoom = await _context.MeetingRoom.FindAsync(id);

            if (meetingRoom == null)
            {
                return NotFound();
            }

            return meetingRoom;
        }

        // PUT: api/MeetingRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetingRoom(int id, MeetingRoom meetingRoom)
        {
            if (id != meetingRoom.Id)
            {
                return BadRequest();
            }

            _context.Entry(meetingRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingRoomExists(id))
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

        // POST: api/MeetingRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MeetingRoom>> PostMeetingRoom(MeetingRoom meetingRoom)
        {
            _context.MeetingRoom.Add(meetingRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeetingRoom", new { id = meetingRoom.Id }, meetingRoom);
        }

        // DELETE: api/MeetingRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeetingRoom(int id)
        {
            var meetingRoom = await _context.MeetingRoom.FindAsync(id);
            if (meetingRoom == null)
            {
                return NotFound();
            }

            _context.MeetingRoom.Remove(meetingRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MeetingRoomExists(int id)
        {
            return _context.MeetingRoom.Any(e => e.Id == id);
        }
    }
}
