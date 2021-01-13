using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eKarte.Models
{
    public class Linija
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Glavni vozac")]
        public int Vozac1Id { get; set; }
        public virtual Osoblje Vozac1 { get; set; }
        [Required]
        [DisplayName("Rezervni vozac")]
        public int Vozac2Id { get; set; }
        public virtual Osoblje Vozac2 { get; set; }

        [Required]
        [DisplayName("Kondukter")]
        public int KondukterId { get; set; }
        public virtual Osoblje Kondukter { get; set; }

        [Required]
        [DisplayName("Bus")]
        public int BusId { get; set; }
        public virtual Bus Bus { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        [DisplayName("Osnovna cijena")]
        public double OsnovnaCijenaLinije { get; set; }
    }
}
