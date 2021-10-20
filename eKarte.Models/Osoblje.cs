using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eKarte.Models
{
    public class Osoblje
    {
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public string JMBG { get; set; }
        [DisplayName("Datum Rođenja")]
        public DateTime DatumRodjenja { get; set; }
        [DisplayName("Datum Zaposlenja")]
        public DateTime DatumZaposljenja { get; set; }
        public string Opis { get; set; }



        [Required]
        [DisplayName("Tip osoblja")]
        public int TipOsobljaId { get; set; }
      
        public virtual TipOsoblja TipOsoblja { get; set; }
        [DisplayName("Spol")]
        public int SpolId { get; set; }

        public virtual Spol Spol { get; set; }

        public string Status { get; set; }

    }
}
