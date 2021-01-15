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
        public int StanicaId { get; set; }
        public virtual Stanica Stanica { get; set; }


        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm:ss tt}")]
        [DisplayName("Dolazak busa na stanicu vrijeme")]
        public DateTime DolazakaVrijeme { get; set; }




    }
}
