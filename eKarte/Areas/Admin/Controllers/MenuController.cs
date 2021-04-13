using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKarte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController:Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
