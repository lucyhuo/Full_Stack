import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PlacesRoutingModule } from './places-routing.module';
import { PlacesComponent } from './places.component';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { PlacesAddComponent } from './places-add/places-add.component';

@NgModule({
  declarations: [
    PlacesComponent,
    PlacesAddComponent
  ],
  imports: [
    CommonModule,
    PlacesRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class PlacesModule { }
