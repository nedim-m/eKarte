using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eKarte.Models
{
   public class Let
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Datum leta")]
        public DateTime DatumLeta { get; set; }

        [Required]
        [DisplayName("Vrijeme leta")]
        public string VrijemeLeta { get; set; }
        [Required]
        [DisplayName("Destinacija")]
        public int AerodromDoId { get; set; }
        public virtual Aerodrom AerodromDo { get; set; }
        [Required]
        [DisplayName("Polazak")]
        public int AerodromOdId { get; set; }
        public virtual Aerodrom AerodromOd { get; set; }
        [Required]
        [DisplayName("Avion")]
        public int AvionId { get; set; }
        public virtual Avion Avion { get; set; }
        
        
        [Required]
        public string Naziv { get; set; }

        [Required]
        [DisplayName("Osnovna cijena karte")]
        public double OsnovnaCijenaLeta { get; set; }
        [Required]
        [Range(5,20)]
        [DisplayName("Broj članova posade")]
        public int BrojPosadeNaletu { get; set; }



    }
}
