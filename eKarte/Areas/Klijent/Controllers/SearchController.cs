using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKarte.Areas.Klijent.Controllers
{
    [Area("Klijent")]
    public class SearchController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public SearchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public SearchViewModel SearchVM { get; set; }
        List<SearchViewModel> ListaRezultata = new List<SearchViewModel>();



        [HttpGet]
        public IActionResult GetAll(string aerodromOd, string aerodromDo, string povratnaLet, DateTime datumlet, int klase)
        {


            if (datumlet.Date.CompareTo(DateTime.Now.Date) < 0)
            {
                datumlet = DateTime.Now.Date;
            }
            List<Models.Let> letovi = new List<Models.Let>();

            if (aerodromOd == null && aerodromDo != null)
            {
                letovi = _unitOfWork.Let.GetAll(includeProperties: "AerodromDo,AerodromOd", filter: x => x.DatumLeta.Date.CompareTo(datumlet) == 0)
                    .Where(i => i.AerodromDo.Naziv.ToLower() == aerodromDo.ToLower()).ToList();
            }
            else if (aerodromDo == null && aerodromOd != null)
            {
                letovi = _unitOfWork.Let.GetAll(includeProperties: "AerodromDo,AerodromOd", filter: x => x.DatumLeta.Date.CompareTo(datumlet) == 0)
                    .Where(i => i.AerodromOd.Naziv.ToLower() == aerodromOd.ToLower()).ToList();
            }
            else if (aerodromDo != null && aerodromOd != null)
            {

                letovi = _unitOfWork.Let.GetAll(includeProperties: "AerodromDo,AerodromOd", filter: x => x.DatumLeta.Date.CompareTo(datumlet) == 0)
                    .Where(i => i.AerodromOd.Naziv.ToLower() == aerodromOd.ToLower() && i.AerodromDo.Naziv.ToLower() == aerodromDo.ToLower()).ToList();
            }
            else
            {
                return View();
            }
            double cijenaFaktor = 1;
            double povratnaCijena = 0;
            if (klase == 2)
            {
                cijenaFaktor = 1.7;
            }
            else if (klase == 1)
                cijenaFaktor = 1.5;


            if (povratnaLet != "null")
            {
                povratnaCijena = 0.3;
            }
            foreach (var i in letovi)
            {
                SearchVM = new SearchViewModel()
                {
                    KlasaAvioKarte = _unitOfWork.KlasaAvioKarte.Get(klase),
                    Letovi = i,
                    Povratna = povratnaLet,
                    Cijena = (i.OsnovnaCijenaLeta + (i.OsnovnaCijenaLeta * povratnaCijena)) * cijenaFaktor
                };
                ListaRezultata.Add(SearchVM);
            }

            return View(ListaRezultata);

        }


    }

}
