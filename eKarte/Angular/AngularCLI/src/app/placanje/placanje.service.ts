import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { AvioKarta } from '../karte/karte.model';

@Injectable({
  providedIn: 'root',
})
export class PlacanjeService {
  constructor(private http: HttpClient) {}

  apirUrl2 = 'Klijent/Karte/Placanje';
  
  placanje(avioKarta: AvioKarta) {
    return this.http.post(environment.apiUrl.concat(this.apirUrl2), avioKarta);
  }
}
