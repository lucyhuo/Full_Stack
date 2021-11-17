import { Component, OnInit } from '@angular/core';
import { CabTypeService } from "../core/services/cab-type.service";
import { CabCard } from '../shared/models/cab-card';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  myPageTitle = "Cabs Booking SPA";
  cabCards: CabCard[] | undefined;

  constructor(private cabTypeService: CabTypeService) { }

  ngOnInit(): void {
    // ngOnInit is one of the most important life cycle hooks method in Angular 
    // it's recommended to use this method to call the api, and to initialize any data property 
    // this method will be called automatically by your angular component after calling constructor 

    // only when you subscribe to the observable you get the data
    // Observable<MovieCard[]>
    this.cabTypeService.getAllCabTypes().subscribe(
      m => {
        this.cabCards = m;
      }
    );

  }

}
