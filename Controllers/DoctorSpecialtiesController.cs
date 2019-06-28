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
    [ApiController]
    public class DoctorSpecialtiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DoctorSpecialtiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DoctorSpecialties
        [HttpGet("api/[controller]/[action]")]
        public async Task<ActionResult<IEnumerable<DoctorSpecialty>>> GetDoctorSpecialties()
        {
            return await _context.DoctorSpecialties.ToListAsync();
        }


        [HttpGet("api/[controller]/[action]/{id}")]
        public ActionResult<List<Specialty>> GetByDoctorId(int id)
        {
            List<Specialty> result = new List<Specialty>();
            var doctorSpecialties = _context.DoctorSpecialties.AsQueryable().Where(x => x.DoctorRef.Id == id).ToList();
            if (doctorSpecialties == null)
            {
                return NotFound();
            }

            foreach (DoctorSpecialty dsp in doctorSpecialties)
            {
                result.Add(_context.Specialties.FirstOrDefault(x => x.Id == dsp.Id));
            }
            return Ok(result);
        }

    }
}
