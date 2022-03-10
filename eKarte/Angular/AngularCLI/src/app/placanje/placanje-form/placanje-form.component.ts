import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AvioKarta, Let } from 'src/app/karte/karte.model';
import { environment } from 'src/environments/environment';
import { PlacanjeService } from '../placanje.service';

@Component({
  selector: 'app-placanje-form',
  templateUrl: './placanje-form.component.html',
  styleUrls: ['./placanje-form.component.css'],
})
export class PlacanjeFormComponent implements OnInit {
  // @Input("logiraniKorisnik") logiraniKorisnik : any;
  // @Input("letIdOutput") letIdOutput : any;
  @ViewChild('ngForm') ngForm: any;
  @Input('formDataLet') formDataLet: Let;

  korisnikMail: string;

  avioKarta: AvioKarta = new AvioKarta();
  constructor(private placanjeService: PlacanjeService) {}

  ngOnInit(): void {}

  submit(ngForm: NgForm) {
    this.avioKarta.datum = new Date();
    this.avioKarta.letId = this.formDataLet.id;
    this.avioKarta.korisnikMail =
      this.formDataLet.logiraniKorisnik == null
        ? this.korisnikMail
        : this.formDataLet.logiraniKorisnik;
    this.avioKarta.cijena = this.formDataLet.osnovnaCijenaLeta;

    this.placanjeService.placanje(this.avioKarta).subscribe(
      (res) => {
        
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
