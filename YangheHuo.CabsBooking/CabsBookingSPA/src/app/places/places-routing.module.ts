import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlacesAddComponent } from './places-add/places-add.component';
import { PlacesComponent } from './places.component';

const routes: Routes = [
  {path: '', component: PlacesComponent},
  {path: 'AddPlace', component: PlacesAddComponent},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PlacesRoutingModule { }
