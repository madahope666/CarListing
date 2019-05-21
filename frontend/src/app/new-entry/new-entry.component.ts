import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-new-entry',
  templateUrl: './new-entry.component.html',
  styleUrls: ['./new-entry.component.css']
})
export class NewEntryComponent {

  constructor(private service: ApiService) { }

  entryForm = new FormGroup({
    brand: new FormControl('', Validators.required),
    modelYear: new FormControl('', Validators.required)
  })

  onSubmit(){
    this.service.addCar(this.entryForm.value).subscribe(data => {
      console.log('Data = ', data);
    }) 
  }

}
