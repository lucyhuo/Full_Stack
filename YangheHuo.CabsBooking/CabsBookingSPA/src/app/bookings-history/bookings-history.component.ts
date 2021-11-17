import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../core/services/api.service';
import { BookingsHistoryService } from '../core/services/bookings-history.service';
import { BookingsHistory } from '../shared/models/bookings-history';

@Component({
  selector: 'app-bookings-history',
  templateUrl: './bookings-history.component.html',
  styleUrls: ['./bookings-history.component.css']
})
export class BookingsHistoryComponent implements OnInit {

  bookings: BookingsHistory[] | undefined;

  constructor(private apiService: ApiService,
    private bookingsService : BookingsHistoryService, private router : Router) { }

  ngOnInit(): void {
    
    this.apiService.getList('BookingsHistories').subscribe(
      b => {
        this.bookings = b;
      }
    )

  }

  delete(id: number){
    this.apiService.delete('Places', id).subscribe();
    window.location.reload();
  }
}
