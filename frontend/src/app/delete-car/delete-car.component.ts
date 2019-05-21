import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-delete-car',
  templateUrl: './delete-car.component.html',
  styleUrls: ['./delete-car.component.css']
})
export class DeleteCarComponent implements OnInit {

  car = {
    brand: '',
    modelYear: ''
  }
  id;

  constructor( private route: ActivatedRoute,
               private service: ApiService,
               private router: Router ) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.service.getSingleCar(this.id).subscribe( (data: any) => {
      this.car.brand = data.brand;
      this.car.modelYear = data.modelYear;
    });
  }

  cancel() {
    this.router.navigate(['/']);
  }

  confirmDelete() { 
    this.service.deleteCar(this.id).subscribe( data => {
      console.log('Confirm Delete Data = ',data);
    })
  }

}
