using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EY_PEP.Data;
using EY_PEP.Models;

namespace EY_PEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalSchoolsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MedicalSchoolsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MedicalSchools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalSchool>>> GetMedicalSchools()
        {
            return await _context.MedicalSchools.ToListAsync();
        }

        // GET: api/MedicalSchools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalSchool>> GetMedicalSchool(int id)
        {
            var medicalSchool = await _context.MedicalSchools.FindAsync(id);

            if (medicalSchool == null)
            {
                return NotFound();
            }

            return medicalSchool;
        }

        // PUT: api/MedicalSchools/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalSchool(int id, MedicalSchool medicalSchool)
        {
            if (id != medicalSchool.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicalSchool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalSchoolExists(id))
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

        // POST: api/MedicalSchools
        [HttpPost]
        public async Task<ActionResult<MedicalSchool>> PostMedicalSchool(MedicalSchool medicalSchool)
        {
            _context.MedicalSchools.Add(medicalSchool);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalSchool", new { id = medicalSchool.Id }, medicalSchool);
        }

        // DELETE: api/MedicalSchools/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicalSchool>> DeleteMedicalSchool(int id)
        {
            var medicalSchool = await _context.MedicalSchools.FindAsync(id);
            if (medicalSchool == null)
            {
                return NotFound();
            }

            _context.MedicalSchools.Remove(medicalSchool);
            await _context.SaveChangesAsync();

            return medicalSchool;
        }

        private bool MedicalSchoolExists(int id)
        {
            return _context.MedicalSchools.Any(e => e.Id == id);
        }
    }
}
