using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eKarte.Models
{
    public class Stanica
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Telefon { get; set; }

        [Required]
        [DisplayName("Grad")]
        public int GradId { get; set; }

        public virtual Grad Grad { get; set; }
    }
}
