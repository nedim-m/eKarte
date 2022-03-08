import { Component, OnInit, Output } from '@angular/core';
import { KarteService } from '../karte.service';
import {
  
  Location,
  LocationStrategy,
  PathLocationStrategy,
} from '@angular/common';
import {  Let } from '../karte.model';
import { environment } from 'src/environments/environment.prod';


@Component({
  selector: 'app-karte-index',
  templateUrl: './karte-index.component.html',
  styleUrls: ['./karte-index.component.css'],
  providers: [
    Location,
    { provide: LocationStrategy, useClass: PathLocationStrategy },
  ],
})
export class KarteIndexComponent implements OnInit {
  public letId: any;

  location1: Location;
  path: string;

  formData: Let;
  

params: string;
cijena:string;
  constructor(
    private service: KarteService,
    private location: Location
   
  ) {
    this.location1 = location;

    this.path = this.location1.path().toString();
   
    this.path = this.path.replace(",",".").replace(/[^0-9&.]/g,'');
    
   

    this.letId = this.path.substring(0, this.path.lastIndexOf("&"));
    this.cijena = this.path.substring(this.path.indexOf("&") +1, 10)
    
    


    this.service.letId = this.letId;
  }

  ngOnInit(): void {
    this.service.getLet().subscribe((karta) => {
      this.formData = karta;
      this.formData.osnovnaCijenaLeta = +this.cijena;
    });
  }
 
  izlaz(){
    window.location.href = environment.apiUrl;
  }
  

}
