using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EY_PEP.Models
{
    public class DoctorSpecialty
    {
        public int Id { get; set; }
        public Doctor DoctorRef { get; set; }
        public Specialty SpecialtyRef { get; set; }
    }
}
