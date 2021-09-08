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
    public class Doctor_DetailsController : ControllerBase
    {
        private readonly Doctor_Appointment_WebAPI_BackEndContext _context;

        public Doctor_DetailsController(Doctor_Appointment_WebAPI_BackEndContext context)
        {
            _context = context;
        }

        // GET: api/Doctor_Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor_Details>>> GetDoctor_Details()
        {
            return await _context.Doctor_Details.ToListAsync();
        }

        // GET: api/Doctor_Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor_Details>> GetDoctor_Details(int id)
        {
            var doctor_Details = await _context.Doctor_Details.FindAsync(id);

            if (doctor_Details == null)
            {
                return NotFound();
            }

            return doctor_Details;
        }

        // PUT: api/Doctor_Details/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor_Details(int id, Doctor_Details doctor_Details)
        {
            if (id != doctor_Details.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctor_Details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Doctor_DetailsExists(id))
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

        // POST: api/Doctor_Details
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doctor_Details>> PostDoctor_Details(Doctor_Details doctor_Details)
        {
            _context.Doctor_Details.Add(doctor_Details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor_Details", new { id = doctor_Details.Id }, doctor_Details);
        }

        // DELETE: api/Doctor_Details/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor_Details(int id)
        {
            var doctor_Details = await _context.Doctor_Details.FindAsync(id);
            if (doctor_Details == null)
            {
                return NotFound();
            }

            _context.Doctor_Details.Remove(doctor_Details);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Doctor_DetailsExists(int id)
        {
            return _context.Doctor_Details.Any(e => e.Id == id);
        }
    }
}
