import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DisplayDoctor } from '../../Models/displayDoctor';
import { Doctor } from '../../models/doctor';
import { HttpClient } from '@angular/common/http';
import { Specialty } from '../../Models/specialty';
import { Language } from '../../Models/language';
import { PatientRating } from '../../Models/patientRating';



@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})

export class DoctorComponent implements OnInit {
  private readonly _http: HttpClient;
  private readonly _baseUrl: string;
  private _route: ActivatedRoute;
  private asyncResult: any

  public selectedDoctor: DisplayDoctor = new DisplayDoctor();

  constructor(route: ActivatedRoute, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
    this._route = route;
 }

  ngOnInit() {
    var selectedDoctorId: string = "0";
    var comments: string[] = new Array();

    this._route.paramMap.subscribe(params => {
          selectedDoctorId = params.get("id");
    });

    this._http.get<Doctor>(this._baseUrl + `api/doctors/${selectedDoctorId}`).subscribe(result => {
      var item: DisplayDoctor = new DisplayDoctor();

        item.id = result.id,
        item.name = result.name,
        item.gender = result.gender,
        this.getSpecialties(result.id).then(function (x) {
          console.log("Specialties: " + result.id + "-" + x);
            item.specialties = x;
        }),

        this.getAvgRating(result.id).then(function (x) {
            console.log("Avg rating: " + result.id + "-" + x);
          item.avgPatientRating = x;
        });

      this.getLanguages(result.id).then(function (x) {
          console.log("Languages: " + result.id + "-" + x);
            item.languages = x;
       }),

       this.getMedicalSchool(result.id).then(function (x) {
            console.log("Medical School: " + result.id + "-" + x);
          item.medicalSchool = x;
        });

      this.getRatings(result.id).then(function (x) {
            console.log("Ratings: " + result.id + "-" + x);
          item.ratings = x;
        });

        this.selectedDoctor = item;
    },
     error => console.error(error));


  }

  async getSpecialties(id: number): Promise<string> {
    var resultString: string = "";

    this.asyncResult = await this._http.get<Specialty[]>(this._baseUrl + `api/DoctorSpecialties/GetByDoctorId/${id}`).toPromise();

    this.asyncResult.forEach(function (value) {
      if (value !== null) {
          resultString += value.name;
          resultString += ',';
        }
    });
    var ret = resultString.substr(0, resultString.length - 1);
      return ret;
  }

  async getAvgRating(id: number): Promise<string> {
    var resultString: string = "";
    this.asyncResult = await this._http.get<string>(this._baseUrl + `api/PatientRatings/GetAvgPatientRating/${id}`).toPromise();
    resultString = this.asyncResult;

    return resultString;
  }

  async getLanguages(id: number): Promise<string> {
    var resultString: string = "";

    this.asyncResult = await this._http.get<Language[]>(this._baseUrl + `api/Languages/GetByDoctorId/${id}`).toPromise();

    this.asyncResult.forEach(function (value) {
      if (value !== null) {
          resultString += value.name;
          resultString += ',';
        }
    });

    var ret = resultString.substr(0, resultString.length - 1);
    return ret;
  }

  async getMedicalSchool(id: number): Promise<string> {
    var resultString: string = "";
    this.asyncResult = await this._http.get<string>(this._baseUrl + `api/MedicalSchools/${id}`).toPromise();
    resultString = this.asyncResult.name;

    return resultString;
  }

  async getRatings(id: number): Promise<PatientRating[]> {
    var resultString: string = "";

    this.asyncResult = await this._http.get<PatientRating[]>(this._baseUrl + `api/PatientRatings/GetPatientRatingComments/${id}`).toPromise();

    return this.asyncResult

  }
}


