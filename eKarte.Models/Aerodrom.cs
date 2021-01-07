using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Models
{
    public class Aerodrom
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public int GradId { get; set; }
        public virtual Grad Grad { get; set; }
    }
}
