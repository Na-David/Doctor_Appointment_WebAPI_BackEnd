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
    public class Patient_DetailsController : ControllerBase
    {
        private readonly Doctor_Appointment_WebAPI_BackEndContext _context;

        public Patient_DetailsController(Doctor_Appointment_WebAPI_BackEndContext context)
        {
            _context = context;
        }

        // GET: api/Patient_Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient_Details>>> GetPatient_Details()
        {
            return await _context.Patient_Details.ToListAsync();
        }

        // GET: api/Patient_Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient_Details>> GetPatient_Details(int id)
        {
            var patient_Details = await _context.Patient_Details.FindAsync(id);

            if (patient_Details == null)
            {
                return NotFound();
            }

            return patient_Details;
        }

        // PUT: api/Patient_Details/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient_Details(int id, Patient_Details patient_Details)
        {
            if (id != patient_Details.Id)
            {
                return BadRequest();
            }

            _context.Entry(patient_Details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Patient_DetailsExists(id))
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

        // POST: api/Patient_Details
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patient_Details>> PostPatient_Details(Patient_Details patient_Details)
        {
            _context.Patient_Details.Add(patient_Details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatient_Details", new { id = patient_Details.Id }, patient_Details);
        }

        // DELETE: api/Patient_Details/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient_Details(int id)
        {
            var patient_Details = await _context.Patient_Details.FindAsync(id);
            if (patient_Details == null)
            {
                return NotFound();
            }

            _context.Patient_Details.Remove(patient_Details);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Patient_DetailsExists(int id)
        {
            return _context.Patient_Details.Any(e => e.Id == id);
        }
    }
}
