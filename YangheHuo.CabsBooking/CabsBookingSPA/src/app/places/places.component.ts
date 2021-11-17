import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ApiService } from '../core/services/api.service';
import { PlaceCard } from '../shared/models/place-card';
import { ValidatorService } from 'src/app/core/services/validator.service';
import { PlaceService } from '../core/services/place.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-places',
  templateUrl: './places.component.html',
  styleUrls: ['./places.component.css']
})
export class PlacesComponent implements OnInit {

  placeCards: PlaceCard[] | undefined;
  

  // convenience getter for easy access to form fields
  constructor(private apiService: ApiService,
    private placeService: PlaceService,
    private validatorService: ValidatorService,
    private fb: FormBuilder,
    private r: Router) { 
     
    }

  ngOnInit(): void {

    this.apiService.getList('Places').subscribe(
      m=>{
        this.placeCards = m;
      }
    )
  }

  delete(id: number){
    this.apiService.delete('Places', id).subscribe();
    window.location.reload();
  }
  // submit(){
  //   this.placeService.create('Places', this.form.value).subscribe(
  //     res => {
  //       this.placeCard = res;
  //       console.log(this.placeCard);
  //     });
      
  // }


}
