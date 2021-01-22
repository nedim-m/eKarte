using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eKarte.Models
{
    public class KlasaAvioKarte
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Hrana { get; set; }
        [Required]
        public string WiFi { get; set; }
        [Required]
        [DisplayName("Sjediste za spavanje")]
        public string PosebnoSjediste { get; set; }
        [Required]
        [DisplayName("USB Port")]
        public string PortZaPunjenjeUredjaja { get; set; }
        [Required]
        [DisplayName("Mjesto do prozora")]
        public string MjestoDoProzora { get; set; }



    }
}
