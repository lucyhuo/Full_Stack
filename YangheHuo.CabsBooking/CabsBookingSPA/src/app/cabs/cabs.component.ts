import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CabTypeService } from '../core/services/cab-type.service';
import { Booking } from '../shared/models/booking';
import { CabCard } from '../shared/models/cab-card';
import { Cab } from '../shared/models/cab';
import { ApiService } from '../core/services/api.service';

@Component({
  selector: 'app-cabs',
  templateUrl: './cabs.component.html',
  styleUrls: ['./cabs.component.css']
})
export class CabsComponent implements OnInit {

  cab!: Cab ;
  id:number=0;

  constructor(private route : ActivatedRoute, 
    private cabService: CabTypeService,
    private apiService: ApiService) { }

  ngOnInit(): void {
    // const routeParams = this.route.snapshot.paramMap;
    // this.id = Number(routeParams.get('cabTypeId'));
    // this.cabService.getAllCabTypes().subscribe(
    //   c=>this.cabs
    // )

    this.route.paramMap.subscribe(p=>{
      this.id=Number(p.get('id'));
      this.cabService.getCabTypeBookingDetails(this.id).subscribe(
        resp=>{
          this.cab = resp;
        }
      )
    })
  }


  deleteCab(id:number){
    this.apiService.delete('CabTypes', id).subscribe(
      c=>{
        window.location.reload();
      }
    )
  }

  // activated route
  // this.activeRoute.paramMap.subscribe(
  //   p => {
  //     // this.id = Number(p.get('id'));

  //     this.cabService.getCabTypesWithBookings(this.id).subscribe(
  //       c=>{
  //         this.cabCard = c;
  //       }
  //     )
  //   }
  // )
}
