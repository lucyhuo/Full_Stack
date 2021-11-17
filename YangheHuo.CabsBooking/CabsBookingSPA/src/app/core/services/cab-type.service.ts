import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cab } from 'src/app/shared/models/cab';
import { CabCard } from 'src/app/shared/models/cab-card';
import { HttpClient } from "@angular/common/http";
import { ApiService } from './api.service';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CabTypeService {

  constructor(private http: HttpClient, 
    private apiService: ApiService) { }



  getAllCabTypes(): Observable<CabCard[]>{
    // call API, using HttpClient to make Get Request 
    // HttpClient class comes from HttpClientModule (Angular has created)
    // import httpclient module inside app module
    // return this.apiService.getAll('CabTypes');
    return this.http.get<CabCard[]>(`${environment.apiUrl}CabTypes`)
  }

  getCabTypeBookingDetails(id: number): Observable<Cab>{
    return this.http.get<Cab>(`${environment.apiUrl}CabTypes/${id}`);
  }

  // getCabTypesWithBookings(id:number):Observable<CabCard>{
  //   return this.apiService.getById(`${'CabTypes'}`,id);
  // }

}
