using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Models.ViewModels
{
    public class AerodromViewModel
    {
        public Aerodrom Aerodrom { get; set; }
        public IEnumerable<SelectListItem> ListaGradova { get; set; }
    }
}
