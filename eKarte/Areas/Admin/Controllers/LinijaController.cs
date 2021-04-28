using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using eKarte.Models.ViewModels;
using eKarte.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eKarte.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticData.Admin)]
    public class LinijaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public LinijaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public LinijaViewModel LinijaVM { get; set; }
        private static int vozac1 = 0;
        
        private static int kondukter = 0;
        private static int bus = 0;

        
        public IActionResult Upsert(int? id)
        {
            var listaV = _unitOfWork.Osoblje.GetAll(includeProperties: "TipOsoblja", filter: o => o.TipOsoblja.Oznaka == StaticData.OznakaBus).Where(i => i.TipOsoblja.Naziv == "Vozac")
                .Where(i => i.Status == StaticData.StatusSlobodno);
            var listaK = _unitOfWork.Osoblje.GetAll(includeProperties: "TipOsoblja", filter: o => o.TipOsoblja.Oznaka == StaticData.OznakaBus).Where(i => i.TipOsoblja.Naziv == "Kondukter")
                .Where(i => i.Status == StaticData.StatusSlobodno);
            var listaB = _unitOfWork.Bus.GetAll().Where(i => i.Status == StaticData.StatusSlobodno);


            LinijaVM = new LinijaViewModel()
            {
                Linija = new Models.Linija(),
                ListaVozacaZaBus = listaV.Select(i => new SelectListItem() { Text = i.Ime + " " + i.Prezime, Value = i.Id.ToString() }),
                ListaKonduktera = listaK.Select(i => new SelectListItem() { Text = i.Ime + " " + i.Prezime, Value = i.Id.ToString() }),
                ListaBuseva = listaB.Select(i => new SelectListItem() { Text = i.Naziv + " |Reg: " + i.RegistracijskaOznaka, Value = i.Id.ToString() }),
                ListaStanica=_unitOfWork.Stanica.GetStanicaListForDropDown()


            };
            if (id != null)
            {
                LinijaVM.Linija = _unitOfWork.Linija.Get(id.GetValueOrDefault());
                vozac1 = LinijaVM.Linija.Vozac1Id;
                
                kondukter = LinijaVM.Linija.KondukterId;
                bus = LinijaVM.Linija.BusId;
                _unitOfWork.Osoblje.Get(LinijaVM.Linija.Vozac1Id).Status = StaticData.StatusSlobodno;
                
                
                _unitOfWork.Osoblje.Get(LinijaVM.Linija.KondukterId).Status = StaticData.StatusSlobodno;
                _unitOfWork.Bus.Get(LinijaVM.Linija.BusId).Status = StaticData.StatusSlobodno;
                


            }
            return View(LinijaVM);
        }
        [HttpPost]
        public IActionResult Upsert()

        {


            var listaV = _unitOfWork.Osoblje.GetAll(includeProperties: "TipOsoblja", filter: o => o.TipOsoblja.Oznaka == StaticData.OznakaBus).Where(i => i.TipOsoblja.Naziv == "Vozac")
                .Where(i => i.Status == StaticData.StatusSlobodno);
            var listaK = _unitOfWork.Osoblje.GetAll(includeProperties: "TipOsoblja", filter: o => o.TipOsoblja.Oznaka == StaticData.OznakaBus).Where(i => i.TipOsoblja.Naziv == "Kondukter")
                .Where(i => i.Status == StaticData.StatusSlobodno);
            var listaB = _unitOfWork.Bus.GetAll(filter: o => o.Status == StaticData.StatusSlobodno);
            if (ModelState.IsValid)
            {

                if (LinijaVM.Linija.Id == 0)
                {



                    _unitOfWork.Linija.Add(LinijaVM.Linija);
                    _unitOfWork.Osoblje.Get(LinijaVM.Linija.Vozac1Id).Status = StaticData.StatusZauzeto;
                    _unitOfWork.Osoblje.Get(LinijaVM.Linija.KondukterId).Status = StaticData.StatusZauzeto;
                    _unitOfWork.Bus.Get(LinijaVM.Linija.BusId).Status = StaticData.StatusZauzeto;

                }
                else
                {




                    _unitOfWork.Linija.Update(LinijaVM.Linija);

                    if (LinijaVM.Linija.Vozac1Id != vozac1)
                    {
                        _unitOfWork.Osoblje.Get(LinijaVM.Linija.Vozac1Id).Status = StaticData.StatusZauzeto;
                        _unitOfWork.Osoblje.Get(vozac1).Status = StaticData.StatusSlobodno;

                    }

                    if (LinijaVM.Linija.KondukterId != kondukter)
                    {
                        _unitOfWork.Osoblje.Get(LinijaVM.Linija.KondukterId).Status = StaticData.StatusZauzeto;
                        _unitOfWork.Osoblje.Get(kondukter).Status = StaticData.StatusSlobodno;

                    }
                    if (LinijaVM.Linija.BusId != bus)
                    {
                        _unitOfWork.Bus.Get(LinijaVM.Linija.BusId).Status = StaticData.StatusZauzeto;
                        _unitOfWork.Bus.Get(bus).Status = StaticData.StatusSlobodno;
                    }
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                LinijaVM.ListaVozacaZaBus = listaV.Select(i => new SelectListItem() { Text = i.Ime + " " + i.Prezime, Value = i.Id.ToString() });
                LinijaVM.ListaKonduktera = listaK.Select(i => new SelectListItem() { Text = i.Ime + " " + i.Prezime, Value = i.Id.ToString() });
                LinijaVM.ListaBuseva = listaB.Select(i => new SelectListItem() { Text = i.Naziv + " " + i.RegistracijskaOznaka, Value = i.Id.ToString() });
                LinijaVM.ListaStanica = _unitOfWork.Stanica.GetStanicaListForDropDown();
                return View(LinijaVM);
            }

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            
            return Json(new { data = _unitOfWork.Linija.GetAll(includeProperties:"Vozac1,Kondukter,Bus,StanicaPocetna.Grad,StanicaZadnja.Grad") });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Linija.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });
            }
            _unitOfWork.Osoblje.Get(objFromDb.Vozac1Id).Status = StaticData.StatusSlobodno;          
            _unitOfWork.Osoblje.Get(objFromDb.KondukterId).Status = StaticData.StatusSlobodno;
            _unitOfWork.Bus.Get(objFromDb.BusId).Status = StaticData.StatusSlobodno;
            _unitOfWork.Linija.Remove(objFromDb);


            _unitOfWork.Save();
            return Json(new { success = true, message = StaticData.SuccessMessage });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
