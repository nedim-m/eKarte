using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eKarte.Models
{
   public class StanicaLinija
    {
        public int Id { get; set; }

        [Required]
        public int LinijaId { get; set; }
        public virtual Linija Linija { get; set; }

        [Required]
        public int StanicaPolazisteId { get; set; }
        public virtual Stanica StanicaPolaziste { get; set; }
        [Required]
        public int StanicaOdredisteId { get; set; }
        public virtual Stanica StanicaOdrediste { get; set; }
        [Required]
        [DisplayName("Polazak busa")]
        public DateTime PolazakVrijeme { get; set; }
        [Required]
        [DisplayName("Dolazak busa")]
        public DateTime DolazakVrijeme { get; set; }
        [Required]
        [Range(1,1000)]
        [DisplayName("Osnovna cijena")]
        public double Cijena { get; set; }
    



    }
}
