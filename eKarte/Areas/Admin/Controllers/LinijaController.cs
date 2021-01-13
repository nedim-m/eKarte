using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models.ViewModels;
using eKarte.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eKarte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LinijaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public LinijaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public LinijaViewModel LinijaVM { get; set; }
        public IActionResult Upsert(int? id)
        {
            var listaV = _unitOfWork.Osoblje.GetAll(includeProperties: "TipOsoblja", filter: o => o.TipOsoblja.Oznaka == StaticData.OznakaBus).Where(i => i.TipOsoblja.Naziv == "Vozac");
            var listaK= _unitOfWork.Osoblje.GetAll(includeProperties: "TipOsoblja", filter: o => o.TipOsoblja.Oznaka == StaticData.OznakaBus).Where(i => i.TipOsoblja.Naziv == "Kondukter");
            LinijaVM = new LinijaViewModel()
            {
                Linija = new Models.Linija(),
                ListaVozacaZaBus = listaV.Select(i => new SelectListItem() { Text = i.Ime + " " + i.Prezime, Value = i.Id.ToString() }),
                ListaKonduktera= listaK.Select(i => new SelectListItem() { Text = i.Ime + " " + i.Prezime, Value = i.Id.ToString() }),
                ListaBuseva = _unitOfWork.Bus.GetListForDropdown()

            };
            if (id != null)
            {
                LinijaVM.Linija = _unitOfWork.Linija.Get(id.GetValueOrDefault());
            }
            return View(LinijaVM);
        }
        [HttpPost]
        public IActionResult Upsert()
        {
            var listaV = _unitOfWork.Osoblje.GetAll(includeProperties: "TipOsoblja", filter: o => o.TipOsoblja.Oznaka == StaticData.OznakaBus).Where(i => i.TipOsoblja.Naziv == "Vozac");
            var listaK = _unitOfWork.Osoblje.GetAll(includeProperties: "TipOsoblja", filter: o => o.TipOsoblja.Oznaka == StaticData.OznakaBus).Where(i => i.TipOsoblja.Naziv == "Kondukter");
            if (ModelState.IsValid)
            {
                if (LinijaVM.Linija.Id == 0)
                {
                    _unitOfWork.Linija.Add(LinijaVM.Linija);
                }
                else
                {
                    _unitOfWork.Linija.Update(LinijaVM.Linija);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                LinijaVM.ListaVozacaZaBus = listaV.Select(i => new SelectListItem() { Text = i.Ime + " " + i.Prezime, Value = i.Id.ToString() });
                LinijaVM.ListaKonduktera = listaK.Select(i => new SelectListItem() { Text = i.Ime + " " + i.Prezime, Value = i.Id.ToString() });
                LinijaVM.ListaBuseva = _unitOfWork.Bus.GetListForDropdown();
                return View(LinijaVM);
            }

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Linija.GetAll(includeProperties: "Vozac1,Vozac2,Kondukter,Bus") });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Linija.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });
            }
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
