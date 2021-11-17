import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HeaderComponent } from './core/layout/header/header.component';
import { HttpClientModule } from "@angular/common/http";
import { HomeComponent } from './home/home.component';
import { CabsComponent } from './cabs/cabs.component';
import { PlacesModule } from './places/places.module';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BookingsHistoryComponent } from './bookings-history/bookings-history.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    CabsComponent,
    BookingsHistoryComponent,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    PlacesModule,
    FormsModule, 
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
