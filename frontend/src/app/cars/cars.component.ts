import { Component, OnInit, ViewChild } from '@angular/core';
import { ApiService } from '../api.service';
import { MatTableModule, MatDialog, MatSort } from '@angular/material';
import { UpdateCarComponent } from '../update-car/update-car.component';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {

  displayedColumns: string[] = ['Brand', 'ModelYear', 'Actions'];
  carList;

  @ViewChild(MatSort) sort: MatSort;

  constructor(private service: ApiService,
              private dialog: MatDialog) { }

  ngOnInit() {
    this.service.getAllCars().subscribe(data => {
      this.carList = data;
    });
  }

  updateTable() {
    this.service.getAllCars().subscribe(data => {
      this.carList = data;
    });
  }

  updateCar(car) {
    this.dialog.open(UpdateCarComponent, {
      data: {
        id: car.carid,
        brand: car.brand,
        modelYear: car.modelYear
      }
    });
  }

}
