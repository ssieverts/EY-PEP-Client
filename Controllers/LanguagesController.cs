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
    public class LanguagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LanguagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("api/[controller]/[action]")]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguages()
        {
            return await _context.Languages.ToListAsync();
        }

        [HttpGet("api/[controller]/[action]/{id}")]
        public ActionResult<List<Language>> GetByDoctorId(int id)
        {
            List<Language> result = new List<Language>();
            var doctorLanguages = _context.Languages.AsQueryable().Where(x => x.DoctorRef.Id == id).ToList();
            if (doctorLanguages == null)
            {
                return NotFound();
            }

            foreach (Language dl in doctorLanguages)
            {
                result.Add(_context.Languages.FirstOrDefault(x => x.Id == dl.Id));
            }
            return Ok(result);
        }

    }
}
