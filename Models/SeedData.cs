using EY_PEP.Data;
using EY_PEP.Models;
using System;
using System.Linq;

public class SeedData
{
    public static void Initialize(ApplicationDbContext db)
    {

        if (!db.Specialties.Any())
        {
            db.Add(new Specialty
            {
                Name = "OB/GYN"
            });
            db.Add(new Specialty
            {
                Name = "Internal Medicine"
            });
            db.Add(new Specialty
            {
                Name = "Pediatrics"
            });
            db.Add(new Specialty
            {
                Name = "General Practitioner"
            });

            db.SaveChanges();
        }

        if (!db.MedicalSchools.Any())
        {
            db.Add(new MedicalSchool
            {
                Name = "Vanderbilt"
            });
            db.Add(new MedicalSchool
            {
                Name = "UGA"
            });
            db.Add(new MedicalSchool
            {
                Name = "Stanford"
            });

            db.SaveChanges();
        }



        if (!db.Doctors.Any())
        {
            db.Add(new Doctor
            {
                Name = "Dr. Jeff Jones",
                Gender = "Male",
                MedicalSchoolRef = db.MedicalSchools.FirstOrDefault(x => x.Name == "UGA"),
            });
            db.Add(new Doctor
            {
                Name = "Dr. Divya Sri Gugulotu",
                Gender = "Female",
                MedicalSchoolRef = db.MedicalSchools.FirstOrDefault(x => x.Name == "Vanderbilt")
            });
            db.Add(new Doctor
            {
                Name = "Dr. Jose Alverez",
                Gender = "Male",
                MedicalSchoolRef = db.MedicalSchools.FirstOrDefault(x => x.Name == "Stanford")
            });
            db.Add(new Doctor
            {
                Name = "Dr. Jenifer Hailey",
                Gender = "Female",
                MedicalSchoolRef = db.MedicalSchools.FirstOrDefault(x => x.Name == "UGA")
            });

            db.SaveChanges();

        }

        if (!db.Languages.Any())
        {
            db.Add(new Language
            {
                Name = "English",
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jeff Jones")

            });
            db.Add(new Language
            {
                Name = "English",
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Divya Sri Gugulotu")

            });
            db.Add(new Language
            {
                Name = "English",
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jose Alverez")

            });
            db.Add(new Language
            {
                Name = "English",
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jenifer Hailey")

            });
            db.Add(new Language
            {
                Name = "Spanish",
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jose Alverez")

            });
            db.Add(new Language
            {
                Name = "Spanish",
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jenifer Hailey")

            });
            db.Add(new Language
            {
                Name = "Hindi",
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Divya Sri Gugulotu")

            });

            db.SaveChanges();
        }

        if (!db.DoctorSpecialties.Any())
        {
            db.Add(new DoctorSpecialty
            {
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jeff Jones"),
                SpecialtyRef = db.Specialties.FirstOrDefault(x => x.Name == "General Practitioner"),
            });
            db.Add(new DoctorSpecialty
            {
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jeff Jones"),
                SpecialtyRef = db.Specialties.FirstOrDefault(x => x.Name == "Pediatrics"),
            });
            db.Add(new DoctorSpecialty
            {
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Divya Sri Gugulotu"),
                SpecialtyRef = db.Specialties.FirstOrDefault(x => x.Name == "Pediatrics"),
            });
            db.Add(new DoctorSpecialty
            {
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jose Alverez"),
                SpecialtyRef = db.Specialties.FirstOrDefault(x => x.Name == "Internal Medicine"),
            });
            db.Add(new DoctorSpecialty
            {
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jose Alverez"),
                SpecialtyRef = db.Specialties.FirstOrDefault(x => x.Name == "General Practitioner"),
            });
            db.Add(new DoctorSpecialty
            {
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jenifer Hailey"),
                SpecialtyRef = db.Specialties.FirstOrDefault(x => x.Name == "OB/GYN"),
            });


            db.SaveChanges();
        }

        if (!db.PatientRatings.Any())
        {
            db.Add(new PatientRating
            {
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jeff Jones"),
                Comments = "The doctor is a great doctor",
                Rating = 90
            });
            db.Add(new PatientRating
            {
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jeff Jones"),
                Comments = "The doctor is a good doctor",
                Rating = 80
            });
            db.Add(new PatientRating
            {
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jenifer Hailey"),
                Comments = "The doctor is a great doctor",
                Rating = 100
            });
            db.Add(new PatientRating
            {
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jenifer Hailey"),
                Comments = "The doctor is a good doctor",
                Rating = 90
            });
            db.Add(new PatientRating
            {
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jose Alverez"),
                Comments = "The doctor is a great doctor",
                Rating = 85
            });
            db.Add(new PatientRating
            {
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Jose Alverez"),
                Comments = "The doctor is a good doctor",
                Rating = 70
            });
            db.Add(new PatientRating
            {
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Divya Sri Gugulotu"),
                Comments = "The doctor is a great doctor",
                Rating = 100
            });
            db.Add(new PatientRating
            {
                DoctorRef = db.Doctors.FirstOrDefault(x => x.Name == "Dr. Divya Sri Gugulotu"),
                Comments = "The doctor is a good doctor",
                Rating = 100
            });
            db.SaveChanges();
        }
    }
}
