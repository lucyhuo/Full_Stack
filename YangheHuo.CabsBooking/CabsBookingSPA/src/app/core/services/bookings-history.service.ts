import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookingsHistory } from 'src/app/shared/models/bookings-history';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class BookingsHistoryService {

  constructor(private apiService: ApiService) { }
    getAllBookingsHistory(): Observable<BookingsHistory[]> {
      return this.apiService.getList('BookingsHistories');
    }
    updateBookingsHistory(resource: any): Observable<BookingsHistory> {
      return this.apiService.update('BookingsHistories/UpdateBookingHistory', resource);
    }
    addBookingsHistory(resource: any): Observable<BookingsHistory> {
      return this.apiService.create('BookingsHistories/AddBookingHistory', resource );
    }

}
