using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Models.ViewModels
{
    public class OsobljeViewModel
    {
        public Osoblje Osoblje { get; set; }
        public IEnumerable<SelectListItem> SpolLista { get; set; }
        public IEnumerable<SelectListItem> TipOsobljaLista { get; set; }
    }
}
