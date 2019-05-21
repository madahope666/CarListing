import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  baseUrl: string = 'http://carlistingmdhp.azurewebsites.net/api/cars/';

  constructor(private http: HttpClient) { }

  getAllCars() {
    return this.http.get(this.baseUrl + 'getAllCars');
  }

  getSingleCar(id) {
    return this.http.get(this.baseUrl + 'getSingleCar/' + id);
  }

  addCar(car) {
    return this.http.post(this.baseUrl + 'addCar', car);
  }

  updateCar(id, car) {
    return this.http.put(this.baseUrl + 'updateCar/' + id, car);
  }

  deleteCar(id) {
    return this.http.delete(this.baseUrl + 'deleteCar/' + id);
  }
}
