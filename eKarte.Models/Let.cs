using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Models
{
   public class Let
    {
        public int Id { get; set; }
        public DateTime DatumLeta { get; set; }
        public string VrijemeLeta { get; set; }

        public int AerodromDoId { get; set; }
        public virtual Aerodrom AerodromDo { get; set; }

        public int AerodromOdId { get; set; }
        public virtual Aerodrom AerodromOd { get; set; }

        public int AvionId { get; set; }
        public virtual Avion Avion { get; set; }



    }
}
