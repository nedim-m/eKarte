using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Models.ViewModels
{
    public class SearchViewModelBus2
    {
        public StanicaLinija Linije { get; set; }
        public VrstaKarte VrstaBusKarte { get; set; }
        public string Povratna { get; set; }
        public string Kompanija { get; set; }
        public DateTime datum { get; set; }
        public double Cijena { get; set; }
    }
}
