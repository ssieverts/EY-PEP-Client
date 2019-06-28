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
    public class PatientRatingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientRatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PatientRatings
        [HttpGet("api/[controller]/[action]")]
        public async Task<ActionResult<IEnumerable<PatientRating>>> GetPatientRatings()
        {
            return await _context.PatientRatings.ToListAsync();
        }


        [HttpGet("api/[controller]/[action]/{id}")]
        public ActionResult<string> GetAvgPatientRating(int id)
        {
            var avg = _context.PatientRatings.Where(x => x.DoctorRef.Id == id).Average(x => x.Rating);

            var avgPatientRating = String.Format("{0:N2}", avg);

            return Ok(avgPatientRating);
        }

        [HttpGet("api/[controller]/[action]/{id}")]
        public async Task<ActionResult<IEnumerable<PatientRating>>> GetPatientRatingComments(int id)
        {
            var comments = await _context.PatientRatings.Where(x => x.DoctorRef.Id == id).ToListAsync();
            return Ok(comments);
        }
    }
}
