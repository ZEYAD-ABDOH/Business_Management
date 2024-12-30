﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectArti.Api.Data;

namespace ProjectArti.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaragesController : ControllerBase
    {
        private readonly My_dbContext _context;

        public GaragesController(My_dbContext context)
        {
            _context = context;
        }

        // GET: api/Garages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Garage>>> GetGarage()
        {
            return await _context.Garage.ToListAsync();
        }

        // GET: api/Garages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Garage>> GetGarage(int id)
        {
            var garage = await _context.Garage.FindAsync(id);

            if (garage == null)
            {
                return NotFound();
            }

            return garage;
        }

        // PUT: api/Garages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarage(int id, Garage garage)
        {
            if (id != garage.Id)
            {
                return BadRequest();
            }

            _context.Entry(garage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarageExists(id))
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

        // POST: api/Garages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Garage>> PostGarage(Garage garage)
        {
            _context.Garage.Add(garage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGarage", new { id = garage.Id }, garage);
        }

        // DELETE: api/Garages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGarage(int id)
        {
            var garage = await _context.Garage.FindAsync(id);
            if (garage == null)
            {
                return NotFound();
            }

            _context.Garage.Remove(garage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GarageExists(int id)
        {
            return _context.Garage.Any(e => e.Id == id);
        }
    }
}
