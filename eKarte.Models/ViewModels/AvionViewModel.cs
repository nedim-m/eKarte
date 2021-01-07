using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Models.ViewModels
{
    public class AvionViewModel
    {
        public Avion Avion { get; set; }
        public IEnumerable<SelectListItem> ListaKompanija { get; set; }
    }
}
