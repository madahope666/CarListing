import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CarsComponent } from './cars/cars.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { NewEntryComponent } from './new-entry/new-entry.component';
import { UpdateCarComponent } from './update-car/update-car.component';
import { DeleteCarComponent } from './delete-car/delete-car.component';

import { ApiService } from './api.service';
import { AppRouterModule } from './app-router.module';

import { ReactiveFormsModule } from '@angular/forms';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {  MatButtonModule,
          MatTableModule,
          MatInputModule,
          MatCardModule,
          MatSelectModule,
          MatToolbarModule,
          MatDialogModule,
          MatListModule,
          MatSortModule
        } from '@angular/material';



@NgModule({
  declarations: [
    AppComponent,
    CarsComponent,
    HeaderComponent,
    FooterComponent,
    NewEntryComponent,
    UpdateCarComponent,
    DeleteCarComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRouterModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatTableModule,
    MatInputModule,
    MatCardModule,
    MatSelectModule,
    MatToolbarModule,
    MatDialogModule,
    MatListModule,
    MatSortModule,
    ReactiveFormsModule
  ],
  entryComponents:[UpdateCarComponent],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
