using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eKarte.Models;
using eKarte.DataAccess.Data.Repository.IRepository;

namespace eKarte.Controllers
{
    [Area("Klijent")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }




        public IActionResult Index()
        {
            var klaseAvioKarte = _unitOfWork.KlasaAvioKarte.GetAll();
            List<VrstaKarte> vrsteKarte = (List<VrstaKarte>)_unitOfWork.VrstaKarte.GetAll();
            ViewData["VrstaKarte"] = vrsteKarte;
            
            return View(klaseAvioKarte);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
