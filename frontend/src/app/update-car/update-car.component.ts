import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-update-car',
  templateUrl: './update-car.component.html',
  styleUrls: ['./update-car.component.css']
})
export class UpdateCarComponent implements OnInit {

  form: FormGroup;
  id: number;

  constructor( private fb: FormBuilder,
               private dialogRef: MatDialogRef<UpdateCarComponent>,
               private service: ApiService,
               @Inject(MAT_DIALOG_DATA){brand, modelYear, id} ) {
                 this.id = id;

                 this.form = fb.group({
                   carid: this.id,
                   brand: [brand, Validators.required],
                   modelYear: [modelYear, Validators.required]
                 });
               }

  ngOnInit() {
  }

  cancel() {
    this.dialogRef.close();
  }

  save() {
    this.service.updateCar(this.id, this.form.value).subscribe(data => {
      if ( data ) {
        this.dialogRef.close();
      } else {
        console.log('Update Failed');
      }
    });
  }

}
