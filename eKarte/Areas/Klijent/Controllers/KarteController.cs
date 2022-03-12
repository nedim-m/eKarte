using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using eKarte.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace eKarte.Areas.Klijent.Controllers
{
    [Area("Klijent")]
    public class KarteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ServisPlacanje _placanjeServis;

        public KarteController(IUnitOfWork unitOfWork,
            UserManager<IdentityUser> userManager,
            IEmailSender emailSender, ServisPlacanje placanjeServis)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _placanjeServis = placanjeServis;
            
        }



        public IActionResult Index(int LetId,double Cijena)
        {
           
            return View();
        }

        [HttpGet]
        public IActionResult GetLet(int Id)
        {
            var result = (_unitOfWork.Let.GetFirstOrDefault(includeProperties: "Avion,AerodromOd,AerodromDo", filter: i => i.Id == Id));
            var userName = User.FindFirstValue(ClaimTypes.Name);
            if (userName != null)
                result.LogiraniKorisnik = userName;
            return Json(result);

        }


        



        [HttpPost]
        public IActionResult Placanje([FromBody] AvioKarta avioKarta)
        {
            if (!_placanjeServis.PlacanjeServis(avioKarta.CreditCard))
                
                
                return BadRequest();

            else
            {

                _unitOfWork.AvioKarta.Add(avioKarta);
                _unitOfWork.Save();

                return Ok();
            }
        }

    }

 
}
