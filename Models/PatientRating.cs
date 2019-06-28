using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EY_PEP.Models
{
    public class PatientRating
    {
        public int Id { get; set;  }
        public Doctor DoctorRef { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
    }
}
