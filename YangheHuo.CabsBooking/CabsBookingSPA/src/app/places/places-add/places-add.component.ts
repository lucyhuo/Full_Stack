import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PlaceService } from 'src/app/core/services/place.service';
import { PlaceCard } from 'src/app/shared/models/place-card';


@Component({
  selector: 'app-places-add',
  templateUrl: './places-add.component.html',
  styleUrls: ['./places-add.component.css']
})
export class PlacesAddComponent implements OnInit {

  place : PlaceCard  = {
    placeName: '',
    placeId: 0
  };
  id! : number;

  constructor(private placesService : PlaceService, 
    private router : Router) { }

  ngOnInit(): void {
  }

  add() {
    console.log('button was clicked');
    this.placesService.addPlaces(this.place).subscribe();
    this.router.navigate(['/Places']);
    console.log(this.place);
  }

}