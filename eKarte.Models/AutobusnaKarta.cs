using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eKarte.Models
{
    public class AutobusnaKarta
    {
        public string Id { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        public int StanicaLinijaId { get; set; }
      
        public StanicaLinija StanicaLinija { get; set; }
    }
}
