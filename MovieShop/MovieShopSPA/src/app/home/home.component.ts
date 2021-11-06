import { Component, OnInit } from '@angular/core';
import { MovieService } from '../core/services/movie.service';
import { MovieCard } from '../shared/models/moviecard';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  mypageTile = "Movie Shop SPA";
  // movieCards
  movieCards!: MovieCard[];

  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
      // ngOnInit is one of the most important life cycle hooks method in angular 
      // It is recommended to use this method to call the API and initialize any dat properties 
      // Will be called automatically by your angular component after calling constructor 
      
      // only when you subscribe to the observable, you get the data 
      // Observable<MovieCard[]>
      // http://localhost:4200/ => HomeComponent 
      this.movieService.getTopRevenueMovies().subscribe(
        m=>{
          this.movieCards = m;
          //console.log("inside the ngOnInit method of Home Component");
          // console.log(this.movieCards);

          // to print an arrary of items in console window use console.table 
          //console.table(this.movieCards);
        }
      );
  }

}
