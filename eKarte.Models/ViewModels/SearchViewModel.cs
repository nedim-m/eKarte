using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Models.ViewModels
{
    public class SearchViewModel
    {
        public Let Letovi { get; set; }
        public KlasaAvioKarte KlasaAvioKarte { get; set; }
        public string Povratna { get; set; }
        public double Cijena { get; set; }
    }
}
