import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CarsComponent } from './cars/cars.component';
import { NewEntryComponent } from './new-entry/new-entry.component';
import { DeleteCarComponent } from './delete-car/delete-car.component';

const routes: Routes = [
    { path: '', component: CarsComponent },
    { path: 'add-car', component: NewEntryComponent },
    { path: 'delete-car/:id', component: DeleteCarComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRouterModule{}
