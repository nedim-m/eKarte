using eKarte.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eKarte.Areas.Klijent.Controllers
{
    [Area("Klijent")]
    public class KarteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

     

        public KarteController(IUnitOfWork unitOfWork
           )
        {
            _unitOfWork = unitOfWork;

        }


        public IActionResult Index(int LetId,double Cijena)
        {
           
            return View();
        }

        [HttpGet]
        public IActionResult GetLet(int Id)
        {
            var result = (_unitOfWork.Let.GetFirstOrDefault(includeProperties: "Avion,AerodromOd,AerodromDo", filter: i => i.Id == Id));
            
            return Json(result);

        }
       




    }
}
