import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './core/layout/header/header.component';
import {HttpClientModule} from "@angular/common/http";
import { MovieCardComponent } from './shared/components/movie-card/movie-card.component';
// import { MoviesModule } from './movies/movies.module';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    MovieCardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
    // ,MoviesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


