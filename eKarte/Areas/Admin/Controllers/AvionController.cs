using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models.ViewModels;
using eKarte.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eKarte.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticData.Admin)]
    public class AvionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AvionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public AvionViewModel AvionVM { get; set; }
        public IActionResult Upsert(int? id)
        {
            AvionVM = new AvionViewModel()
            {
                Avion = new Models.Avion(),
                ListaKompanija = _unitOfWork.Kompanija.GetListForDropdown()
            };
            if (id != null)
            {
                AvionVM.Avion = _unitOfWork.Avion.Get(id.GetValueOrDefault());
            }
            return View(AvionVM);
        }
        [HttpPost]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (AvionVM.Avion.Id == 0)
                {
                    _unitOfWork.Avion.Add(AvionVM.Avion);
                }
                else
                {
                    _unitOfWork.Avion.Update(AvionVM.Avion);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                AvionVM.ListaKompanija = _unitOfWork.Kompanija.GetListForDropdown();
                return View(AvionVM);
            }
            
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Avion.GetAll(includeProperties: "Kompanija") });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Avion.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });
            }
            _unitOfWork.Avion.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = StaticData.SuccessMessage });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
