
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProjectArti.Api.Data;
using ProjectArti.Api.Model;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly My_dbContext _context;

        public JobApplicationsController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/JobApplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobApplication>>> GetjobApplications()
        {

            var companies = await _context.jobApplications
            .Include(c => c.Company) // 
            .Select(c => new
            {

                JobApplication=c.Id,
                Position=c.Position,
                DescriptionJobApplication = c.Description,
                ResumeCV=c.ResumeCV,
                ApplicationDate=c.ApplicationDate,
                StatuApplicant=c.StatuApplicant,    
                CompanyName = c.Company.Name,
                businessTypeInCompany = c.Company.businessType.Name
              
               
            })
            .ToListAsync();

            return Ok(companies);

        }

        // GET: api/JobApplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplication>> GetJobApplication(int id)
        {
            var jobApplication = await _context.jobApplications.FindAsync(id);

            if (jobApplication == null)
            {
                return NotFound();
            }

            return jobApplication;
        }

        // PUT: api/JobApplications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobApplication(int id, JobApplication jobApplication)
        {
            if (id != jobApplication.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobApplicationExists(id))
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

        // POST: api/JobApplications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobApplication>> PostJobApplication(JobApplication jobApplication)
        {
            _context.jobApplications.Add(jobApplication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobApplication", new { id = jobApplication.Id }, jobApplication);
        }

        // DELETE: api/JobApplications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobApplication(int id)
        {
            var jobApplication = await _context.jobApplications.FindAsync(id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            _context.jobApplications.Remove(jobApplication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobApplicationExists(int id)
        {
            return _context.jobApplications.Any(e => e.Id == id);
        }
    }
}
