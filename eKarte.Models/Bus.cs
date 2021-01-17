using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eKarte.Models
{
    public class Bus
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Proizvodjac { get; set; }

        [Required]
        public string Model { get; set; }
        [Required]
        [DisplayName("Godina proizvodnje")]
        public int GodinaProizvodnje { get; set; }
        [Required]
        public int Kapacitet { get; set; }

        public virtual TipBusa TipBusa { get; set; }
        [Required]
        [DisplayName("Tip busa")]
        public int TipBusaId { get; set; }
        public virtual Kompanija Kompanija { get; set; }
        [Required]
        [DisplayName("Kompanija")]
        public int KompanijaId { get; set; }
        [Required]
        [DisplayName("Registracijska oznaka")]
        public string RegistracijskaOznaka { get; set; }

        public string Status { get; set; }

    }
}
