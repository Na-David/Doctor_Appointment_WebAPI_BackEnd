using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Doctor_Appointment_WebAPI_BackEnd.Data;
using Doctor_Appointment_WebAPI_BackEnd.Models;

namespace Doctor_Appointment_WebAPI_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Appointment_DetailsController : ControllerBase
    {
        private readonly Doctor_Appointment_WebAPI_BackEndContext _context;

        public Appointment_DetailsController(Doctor_Appointment_WebAPI_BackEndContext context)
        {
            _context = context;
        }

        // GET: api/Appointment_Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment_Details>>> GetAppointment_Details()
        {
            return await _context.Appointment_Details.ToListAsync();
        }

        // GET: api/Appointment_Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment_Details>> GetAppointment_Details(int id)
        {
            var appointment_Details = await _context.Appointment_Details.FindAsync(id);

            if (appointment_Details == null)
            {
                return NotFound();
            }

            return appointment_Details;
        }

        // PUT: api/Appointment_Details/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment_Details(int id, Appointment_Details appointment_Details)
        {
            if (id != appointment_Details.Id)
            {
                return BadRequest();
            }

            _context.Entry(appointment_Details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Appointment_DetailsExists(id))
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

        // POST: api/Appointment_Details
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment_Details>> PostAppointment_Details(Appointment_Details appointment_Details)
        {
            _context.Appointment_Details.Add(appointment_Details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointment_Details", new { id = appointment_Details.Id }, appointment_Details);
        }

        // DELETE: api/Appointment_Details/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment_Details(int id)
        {
            var appointment_Details = await _context.Appointment_Details.FindAsync(id);
            if (appointment_Details == null)
            {
                return NotFound();
            }

            _context.Appointment_Details.Remove(appointment_Details);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Appointment_DetailsExists(int id)
        {
            return _context.Appointment_Details.Any(e => e.Id == id);
        }
    }
}
