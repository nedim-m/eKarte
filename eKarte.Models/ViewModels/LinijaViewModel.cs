using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Models.ViewModels
{
    public class LinijaViewModel
    {
        public Linija Linija { get; set; }
        public IEnumerable<SelectListItem> ListaVozacaZaBus { get; set; }
        public IEnumerable<SelectListItem> ListaKonduktera { get; set; }
        public IEnumerable<SelectListItem> ListaBuseva { get; set; }
       public IEnumerable<SelectListItem> ListaStanica { get; set; }

    }
}
