
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AvioKarta, Let } from 'src/app/karte/karte.model';
import { environment } from 'src/environments/environment';
import { PlacanjeService } from '../placanje.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-placanje-form',
  templateUrl: './placanje-form.component.html',
  styleUrls: ['./placanje-form.component.css'],
})
export class PlacanjeFormComponent implements OnInit {

  public isSpinnerVisible = false;
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
    this.avioKarta.konacnaCijena = this.formDataLet.osnovnaCijenaLeta;
    this.spinnerShow(); 
    this.placanjeService.placanje(this.avioKarta).subscribe({
     
      next: (v) =>   setTimeout(() => {
        this.spinnerHide();
      }, 3000),
      error: (e) => console.error("Unable to save avio karta"),
      complete: () => setTimeout(() => {
        this.success()
      }, 3000) 
  })
  }

  success()
  {
    Swal.fire({
      position: 'center',
      icon: 'success',
      title: 'Avio karte uspješno kupljena!',
      showConfirmButton: false,
      timer: 3000
    }) 
    setTimeout(() => {
      window.location.href = environment.apiUrl;
    }, 2500);
    
  }


  spinnerShow()
  {
    this.isSpinnerVisible = true;
  }

  spinnerHide()
  {
    this.isSpinnerVisible = false;
  }
}
