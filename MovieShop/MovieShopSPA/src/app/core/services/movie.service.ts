import { Injectable } from '@angular/core';
import {Observable } from "rxjs";
import { MovieCard } from 'src/app/shared/models/moviecard';
import { HttpClient } from '@angular/common/http';



@Injectable({
  providedIn: 'root'
})
export class MovieService {

  // private readonly HttpClient _http;
  constructor(private http: HttpClient) { }
  // http://localhost:5001/api/Movies/toprevenue
  // many methods that will be used by components 
  // home component will call this function 

  // return type: Observable of list of MovieCard
  // in C# to do ascyn programming we return Task of list of MovieCard
  getTopRevenueMovies(): Observable<MovieCard[]>  {
      // call our API, using HttpClient (XMLHttpRequest) to make GET request 
      // HttpClient class compes from HttpClientModule (Angular Team created for us to use)
      // import HttpClientModel inside AppModule
      return this.http.get<MovieCard[]>("https://localhost:44332/api/Movies/toprevenue");
  }
}
