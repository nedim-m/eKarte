using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eKarte.Models.ViewModels
{
    public class StanicaLinijaViewModel
    {
        
        public Linija Linija { get; set; }
        [Required]
        [DisplayName("Stanica Polaska")]
        public int StanicaPolaskaId { get; set; }
        public IEnumerable<SelectListItem> StanicaLista { get; set; }
     
        [DisplayName("Polazak busa sa stanice")]
        public DateTime PolazakVrijeme { get; set; }


        [Required]
        [DisplayName("Stanica Dolaska")]
        public int StanicaDolaskaId { get; set; }
        [Required]
        [DisplayName("Dolazak busa na stanicu")]
        public DateTime DolazakaVrijeme { get; set; }

        [Required]
        [DisplayName("Osnovna cijena")]
        public double OsnovnaCijenaLinije { get; set; }
    }
}
