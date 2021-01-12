using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.Models.ViewModels
{
    public class StanicaViewModel
    {
        public Stanica Stanica{ get; set; }
        public IEnumerable<SelectListItem> GradList { get; set; }
    }
}
