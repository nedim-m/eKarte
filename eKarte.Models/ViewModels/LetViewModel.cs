using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Models.ViewModels
{
    public class LetViewModel
    {
        public Let Let { get; set; }
        public IEnumerable<SelectListItem> AerodromOdLista { get; set; }
        public IEnumerable<SelectListItem> AerodromDoLista { get; set; }
        public IEnumerable<SelectListItem> AvionLista { get; set; }
    }
}
