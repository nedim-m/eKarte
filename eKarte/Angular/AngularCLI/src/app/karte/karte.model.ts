export interface Let {
    id: number;
    datumLeta: Date;
    vrijemeLeta: number;
    aerodromDoId: number;
    aerodromDo: Aerodrom;
    aerodromOdId: number;
    aerodromOd: Aerodrom;
    avionId: number;
    avion: Avion;
    naziv: string;
    osnovnaCijenaLeta: number;
    brojPosadeNaletu: number;
    logiraniKorisnik:string;
    
  }
   
  export class Aerodrom{
    id:number;
    naziv:string;
    sifra: string;
    gradId: number;
    grad: string;
  }
  export class Avion{
    id:number;
    naziv:string;
    proizvodjac:string;
    model:string;
    godinaProizvodnje: number;
    kapacitet: number;
    kompanijaId: number;
    kompanija:string;
  
  }
  export class AvioKarta{
    datum:Date;
    letId: number;
    korisnikMail:string;
    konacnaCijena:number;
  }