using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Models
{
    public class Avion
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Proizvodjac { get; set; }
        public string Model { get; set; }
        public int GodinaProizvodnje { get; set; }
        public int Kapacitet { get; set; }
        public int KompanijaId { get; set; }
        public virtual Kompanija Kompanija { get; set; }

    }
}
