import { Component, Inject, OnInit } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Doctor } from "../../models/doctor";
import { Specialty } from '../../Models/specialty';
import { DisplayDoctor } from '../../Models/displayDoctor';

@Component({
  selector: 'app-doctors',
  templateUrl: './doctors.component.html',
  styleUrls: ['./doctors.component.css']
})
export class DoctorsComponent{
  public displayDoctors: DisplayDoctor[] = new Array();
  
  private readonly _http: HttpClient
  private readonly _baseUrl: string
  private asyncResult: any
  
  private selectedDoctor: DisplayDoctor;

  constructor( http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
    
 }

  ngOnInit() {


     this._http.get<Doctor[]>(this._baseUrl + 'api/doctors').subscribe(result => {
        result.forEach(value => {
        let item = {} as DisplayDoctor;

        item.id = value.id,
        item.name = value.name,
        item.gender = value.gender,
        this.getSpecialties(value.id).then(function (x) {
          console.log("Specialties: " + value.id + "-" + x);
            item.specialties = x;
        }),

          this.getAvgRating(value.id).then(function (x) {
            console.log("Avg rating: " + value.id + "-" + x);
          item.avgPatientRating = x;
        });

        this.displayDoctors.push(item);
    },
     error => console.error(error));
    });

    

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
    console.log("Avg: " + this.asyncResult);
    resultString = this.asyncResult;

    return resultString;
  }
}
