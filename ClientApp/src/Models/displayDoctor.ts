import { PatientRating } from "./patientRating";

export class DisplayDoctor{
  id: number;
  name: string;
  gender: string;
  specialties:string;
  avgPatientRating: string;
  medicalSchool: string;
  languages: string;
  ratings: PatientRating[];
}
