import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams }  from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private headers: HttpHeaders;
  constructor(protected http: HttpClient) {
    this.headers = new HttpHeaders();
    this.headers.append('Content-type', 'application/json');
  }

  getList(path: string, id?: number): Observable<any[]> {
    let getUrl: string;
    if (id) {
      getUrl = `${environment.apiUrl}${path}` + '/' + id;
    }
    else {
      getUrl = `${environment.apiUrl}${path}`;
    }
    return this.http
      .get(getUrl)
      .pipe(map(resp => resp as any[])
      )
  }

  getOne(path: string, id?: number): Observable<any> {
    let getUrl: string;
    getUrl = `${environment.apiUrl}${path}` + '/' + id;
    //if (id) {
      //getUrl = `${environment.apiUrl}${path}` + '/' + id;
    //}
    //else {
      //getUrl = `${environment.apiUrl}${path}`;
    //}
    return this.http.get(getUrl).pipe(map((resp) => resp as any[]));
  }

  //post method
  create(path: string, resource: any, options?: any): Observable<any> {
    return this.http
    .post(`${environment.apiUrl}${path}`, resource, {headers: this.headers})
    .pipe(map((response) => response));
  }

  //put method
  update(path: string,resource: any, options?:any):Observable<any> {
    return this.http
    .put(`${environment.apiUrl}${path}`,resource,{headers:this.headers})
    .pipe(map(response=>response));
  }

  //delete method
  delete(path: string, id:number): Observable<any[]> {
    return this.http
    .delete(`${environment.apiUrl}${path}` + '/' + id)
    .pipe(map(resp=>resp as any[]));
  }

}