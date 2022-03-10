using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eKarte.Areas.Klijent.Controllers
{
    [Area("Klijent")]
    public class KarteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        


        public KarteController(IUnitOfWork unitOfWork,
            UserManager<IdentityUser> userManager,
            IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            
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
            _unitOfWork.AvioKarta.Add(avioKarta);
            _unitOfWork.Save();

            return Ok();
        }


     




    }
}
