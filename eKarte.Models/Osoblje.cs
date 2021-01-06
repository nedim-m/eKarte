using System;
using System.Collections.Generic;
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
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumZaposljenja { get; set; }
        public string Opis { get; set; }


        public int TipOsobljaId { get; set; }

        public virtual TipOsoblja TipOsoblja { get; set; }

        public int SpolId { get; set; }

        public virtual Spol Spol { get; set; }

    }
}
