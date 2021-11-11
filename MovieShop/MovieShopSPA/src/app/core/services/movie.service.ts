import { Injectable } from '@angular/core';
import {Observable } from "rxjs";
import { MovieCard } from 'src/app/shared/models/moviecard';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Movie } from 'src/app/shared/models/movie';




// means you can inject this class to any constructor in anywhere in the application
@Injectable({
  providedIn: 'root'
})
export class MovieService {

  // private readonly HttpClient _http; DI 
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
      
      // read the base API URL from the environmen file and then append the needed URL per method 
      return this.http.get<MovieCard[]>(`${environment.apiBaseUrl}movies/toprevenue`);
  }

  // localhost need to be configurable, appSetting.json 
  // movieId should be a parameter 
  getMovieDetails(id: number): Observable<Movie> {

    return this.http.get<Movie>(`${environment.apiBaseUrl}movies/${id}`);
  }

}
