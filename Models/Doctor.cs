using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EY_PEP.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public MedicalSchool MedicalSchoolRef { get; set; }
        //public int LanguageId { get; set; }
        public IEnumerable<PatientRating> PatientRatings { get; set; }
        public IEnumerable<DoctorSpecialty> DoctorSpecialties { get; set; }
        public IEnumerable<Language> Languages { get; set; }

    }
}
