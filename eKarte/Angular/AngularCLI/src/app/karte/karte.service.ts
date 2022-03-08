import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { Let } from './karte.model';

@Injectable({
  providedIn: 'root'
})
export class KarteService {

  letId:number;
  constructor(private http: HttpClient) { }

  apirUrl2='Klijent/Karte/GetLet?Id=';

getLet():Observable<Let>{
  return this.http.get<Let>(environment.apiUrl+this.apirUrl2+this.letId);
}

}
