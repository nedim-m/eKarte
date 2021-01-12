using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Models.ViewModels
{
    public class BusViewModel
    {
        public Bus Bus { get; set; }
        public IEnumerable<SelectListItem> ListaTipova { get; set; }
        public IEnumerable<SelectListItem> ListaKompanija { get; set; } 

    }
}
