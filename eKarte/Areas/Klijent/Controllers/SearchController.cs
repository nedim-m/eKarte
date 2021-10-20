using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
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
        public SearchViewModelBus SearchVMBus { get; set; }
        List<SearchViewModelBus> ListaRezultataBus = new List<SearchViewModelBus>();
        public SearchViewModelBus2 SearchVMBus2 { get; set; }
        List<SearchViewModelBus2> ListaRezultataBus2 = new List<SearchViewModelBus2>();

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
        [HttpGet]
        public IActionResult GetAllLinije(string StanicaPocetna, string StanicaZadnja, string povratnaBus, DateTime datumBus, int vrste)
        {


            if (datumBus.Date.CompareTo(DateTime.Now.Date) < 0)
            {
                datumBus = DateTime.Now.Date;
            }
            List<Models.Linija> linije = new List<Models.Linija>();

            if (StanicaPocetna == null && StanicaZadnja != null)
            {
                linije = _unitOfWork.Linija.GetAll(includeProperties: "StanicaZadnja,StanicaZadnja.Grad,StanicaPocetna,StanicaPocetna.Grad,Bus,Bus.Kompanija", filter: x => x.PolazakVrijeme.Date.CompareTo(datumBus) == 0 || x.Svakodnevna==true)
                    .Where(i => i.StanicaZadnja.Grad.Naziv.ToLower() == StanicaZadnja.ToLower()).ToList();
            }
            else if (StanicaZadnja == null && StanicaPocetna != null)
            {
                linije = _unitOfWork.Linija.GetAll(includeProperties: "StanicaZadnja,StanicaZadnja.Grad,StanicaPocetna,StanicaPocetna.Grad,Bus,Bus.Kompanija", filter: x => x.PolazakVrijeme.Date.CompareTo(datumBus) == 0 || x.Svakodnevna == true)
                    .Where(i => i.StanicaPocetna.Grad.Naziv.ToLower() == StanicaPocetna.ToLower()).ToList();
            }
            else if (StanicaZadnja != null && StanicaPocetna != null)
            {

                linije = _unitOfWork.Linija.GetAll(includeProperties: "StanicaZadnja,StanicaZadnja.Grad,StanicaPocetna,StanicaPocetna.Grad,Bus,Bus.Kompanija", filter: x => x.PolazakVrijeme.Date.CompareTo(datumBus) == 0 || x.Svakodnevna == true)
                    .Where(i => i.StanicaPocetna.Grad.Naziv.ToLower() == StanicaPocetna.ToLower() && i.StanicaZadnja.Grad.Naziv.ToLower() == StanicaZadnja.ToLower()).ToList();
            }
            else
            {
                return View();
            }
            double cijenaFaktor = 1;
            double povratnaCijena = 0;
            var karte = _unitOfWork.VrstaKarte.GetAll();
            foreach(var i in karte)
            {
                if (i.Id == vrste)
                {
                    cijenaFaktor = (100 - i.Popust) / 100;
                }
                

            }
            if (cijenaFaktor == 0)
                cijenaFaktor = 1;

            if (povratnaBus != "null")
            {
                povratnaCijena = 0.3;
            }
            foreach (var i in linije)
            {
                SearchVMBus = new SearchViewModelBus()
                {
                    VrstaBusKarte = _unitOfWork.VrstaKarte.Get(vrste),
                    Linije = i,
                    Povratna = povratnaBus, 
                    Kompanija=i.Bus.Kompanija.Naziv,
                    Cijena = (i.OsnovnaCijenaLinije + (i.OsnovnaCijenaLinije * povratnaCijena)) * cijenaFaktor
                };
                if (i.Svakodnevna)
                {
                    SearchVMBus.datum = datumBus;
                    SearchVMBus.datum = SearchVMBus.datum.AddHours(i.PolazakVrijeme.Hour);
                    SearchVMBus.datum = SearchVMBus.datum.AddMinutes(i.PolazakVrijeme.Minute);
                   
                    
                }
                else
                {
                    SearchVMBus.datum = i.PolazakVrijeme;
                }
                
                ListaRezultataBus.Add(SearchVMBus);
            }
            if (datumBus.Date.CompareTo(DateTime.Now.Date) < 0)
            {
                datumBus = DateTime.Now.Date;
            }
            List<Models.StanicaLinija> linije2 = new List<Models.StanicaLinija>();

            if (StanicaPocetna == null && StanicaZadnja != null)
            {
                linije2 = _unitOfWork.StanicaLinija.GetAll(includeProperties: "StanicaOdrediste,StanicaOdrediste.Grad,StanicaPolaziste,StanicaPolaziste.Grad,Linija,Linija.Bus,Linija.Bus.Kompanija", filter: x => x.PolazakVrijeme.Date.CompareTo(datumBus) == 0 || x.Linija.Svakodnevna == true)
                    .Where(i => i.StanicaOdrediste.Grad.Naziv.ToLower() == StanicaZadnja.ToLower()).ToList();
            }
            else if (StanicaZadnja == null && StanicaPocetna != null)
            {
                linije2 = _unitOfWork.StanicaLinija.GetAll(includeProperties: "StanicaOdrediste,StanicaOdrediste.Grad,StanicaPolaziste,StanicaPolaziste.Grad,Linija,Linija.Bus,Linija.Bus.Kompanija", filter: x => x.PolazakVrijeme.Date.CompareTo(datumBus) == 0 || x.Linija.Svakodnevna == true)
                    .Where(i => i.StanicaPolaziste.Grad.Naziv.ToLower() == StanicaPocetna.ToLower()).ToList();
            }
            else if (StanicaZadnja != null && StanicaPocetna != null)
            {

                linije2 = _unitOfWork.StanicaLinija.GetAll(includeProperties: "StanicaOdrediste,StanicaOdrediste.Grad,StanicaPolaziste,StanicaPolaziste.Grad,Linija,Linija.Bus,Linija.Bus.Kompanija", filter: x => x.PolazakVrijeme.Date.CompareTo(datumBus) == 0 || x.Linija.Svakodnevna == true)
                    .Where(i => i.StanicaPolaziste.Grad.Naziv.ToLower() == StanicaPocetna.ToLower() && i.StanicaOdrediste.Grad.Naziv.ToLower() == StanicaZadnja.ToLower()).ToList();
            }
            else
            {
                return View();
            }
            cijenaFaktor = 1;
              povratnaCijena = 0;
            foreach (var i in karte)
            {
                if (i.Id == vrste)
                {
                    cijenaFaktor = (100-i.Popust)/100;
                }
                

            }
            if (cijenaFaktor == 0)
                cijenaFaktor = 1;
            if (povratnaBus != "null")
            {
                povratnaCijena = 0.3;
            }
            foreach (var i in linije2)
            {
                SearchVMBus2 = new SearchViewModelBus2()
                {
                    VrstaBusKarte = _unitOfWork.VrstaKarte.Get(vrste),
                    Linije = i,
                    Povratna = povratnaBus,
                    datum=i.PolazakVrijeme,
                    Kompanija=i.Linija.Bus.Kompanija.Naziv,
                    Cijena = (i.Cijena + (i.Cijena * povratnaCijena)) * cijenaFaktor
                };
                if (i.Linija.Svakodnevna)
                {
                    SearchVMBus2.datum = datumBus;
                    SearchVMBus2.datum=SearchVMBus2.datum.AddHours(i.PolazakVrijeme.Hour);
                    SearchVMBus2.datum=SearchVMBus2.datum.AddMinutes(i.PolazakVrijeme.Minute);
                }
                else
                {
                    SearchVMBus2.datum = i.PolazakVrijeme;
                }
                ListaRezultataBus2.Add(SearchVMBus2);
            }
            ViewData["Lista2"] = ListaRezultataBus2;

            return View(ListaRezultataBus);

        }



    }

}
