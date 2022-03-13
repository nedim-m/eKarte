using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using eKarte.Models.ViewModels;
using eKarte.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Claims;

namespace eKarte.Areas.Klijent.Controllers
{
    [Area("Klijent")]
    public class KarteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ServisPlacanje _placanjeServis;
        private readonly GenerisanjePdf _pdf;
        private readonly IWebHostEnvironment _env;
        private readonly IEmailSender _emailSender;

        public KarteController(IUnitOfWork unitOfWork,
            UserManager<IdentityUser> userManager,
            IEmailSender emailSender, ServisPlacanje placanjeServis, GenerisanjePdf pdf, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _placanjeServis = placanjeServis;
            _pdf = pdf;
            _env = env;
            _emailSender = emailSender;

        }



        public IActionResult Index(int LetId, double Cijena)
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
                var model = GetKartaForMail(avioKarta);
               _pdf.ConvertToDocument(_env, model);

                _emailSender.SendEmailAsync(avioKarta.KorisnikMail, "Karta", "Poštovani, Vaša karta se nalazi u priloženom pdf fajlu.");
                

                _unitOfWork.AvioKarta.Add(avioKarta);
                _unitOfWork.Save();

                return Ok();
            }
        }

        public AvioKartaViewModel GetKartaForMail(AvioKarta obj)
        {
            string RandAlphabet = "ABCDEFGHIJKL";
            int num = RandAlphabet.Length;
            Random randomNumber = new Random();
            
            Let let = _unitOfWork.Let.GetFirstOrDefault(includeProperties: "Avion,AerodromOd,AerodromDo", filter: i => i.Id == obj.LetId);
            Avion avion = _unitOfWork.Avion.GetFirstOrDefault(includeProperties: "Kompanija", filter: i => i.Id == let.AvionId);
            var model = new AvioKartaViewModel
            {
                BrojLeta = let.Id.ToString(),
                Od = let.AerodromOd.Sifra,
                Do = let.AerodromDo.Sifra,
                Email = obj.KorisnikMail,
                Sjediste = randomNumber.Next(1, let.Avion.Kapacitet).ToString(),
                Kompanija = avion.Kompanija.Naziv,
                Ukrcavanje = let.DatumLeta.ToShortDateString() + " | " + let.DatumLeta.ToShortTimeString(),
                Ulaz = let.Id.ToString() + RandAlphabet[randomNumber.Next(0, num)].ToString()
            };

            return model;
        }

    }


}
