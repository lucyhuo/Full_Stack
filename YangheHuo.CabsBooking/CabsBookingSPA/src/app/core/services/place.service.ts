
import { PlaceCard } from 'src/app/shared/models/place-card';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams }  from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';


@Injectable({
  providedIn: 'root'
})
export class PlaceService {

  constructor(protected http: HttpClient,
    private apiService: ApiService) {
  }

  // create(path: string, resource: any, options?: any): Observable<any> {
  //   return this.http
  //   .post(`${environment.apiUrl}${path}`, resource, {headers: this.headers})
  //   .pipe(map((response) => response));
  // }
  getAllPlaces(): Observable<PlaceCard[]> {
    return this.apiService.getList('Places');
  }
  // deletePlaces(id : number): Observable<PlaceCard> {
  //   return this.apiService.delete( `${`places/delete/`}${id}`);
  // }
  updatePlaces(resource: any): Observable<PlaceCard> {
    return this.apiService.update('Places/UpdatePlace', resource);
  }
  addPlaces(resource: any): Observable<PlaceCard> {
    return this.apiService.create('Places/AddPlace', resource );
  }

}
