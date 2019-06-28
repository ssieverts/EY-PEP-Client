using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EY_PEP.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Doctor DoctorRef { get; set; }

    }
}
