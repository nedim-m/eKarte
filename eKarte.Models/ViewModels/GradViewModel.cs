using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Models.ViewModels
{
   public class GradViewModel
    {
        public Grad Grad { get; set; }
        public IEnumerable<SelectListItem> DrzavaLista { get; set; }

    }
}
