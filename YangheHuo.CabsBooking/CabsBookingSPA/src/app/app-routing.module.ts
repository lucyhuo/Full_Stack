import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BookingsHistoryComponent } from './bookings-history/bookings-history.component';
import { CabsComponent } from './cabs/cabs.component';
import { HomeComponent } from './home/home.component';
// import { CabCardComponent } from './shared/components/cab-card/cab-card.component';

const routes: Routes = [
  {path: "", component: HomeComponent, pathMatch: "full"},
  {path: "BookingHistories", component: BookingsHistoryComponent, pathMatch: "full"},
  {path: "CabTypes/:id", component: CabsComponent},
  {
    path:"Places",
    loadChildren:()=> import("./places/places.module").then(mod => mod.PlacesModule)
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
