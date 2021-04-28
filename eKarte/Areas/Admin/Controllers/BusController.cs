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
    public class BusController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public BusViewModel BusVM { get; set; }
        public IActionResult Upsert(int? id)
        {
            BusVM = new BusViewModel()
            {
                Bus = new Models.Bus(),
                ListaKompanija = _unitOfWork.Kompanija.GetListForDropdown(),
                ListaTipova = _unitOfWork.TipBusa.GetTipBusaListForDropDown()
            
            
            };
            if (id != null)
            {
                BusVM.Bus = _unitOfWork.Bus.Get(id.GetValueOrDefault());
            }
            return View(BusVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (BusVM.Bus.Id == 0)
                {
                    BusVM.Bus.Status = StaticData.StatusSlobodno;
                    _unitOfWork.Bus.Add(BusVM.Bus);
                }
                else
                {
                    _unitOfWork.Bus.Update(BusVM.Bus);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                BusVM.ListaKompanija = _unitOfWork.Kompanija.GetListForDropdown();
                BusVM.ListaTipova = _unitOfWork.TipBusa.GetTipBusaListForDropDown();
                return View(BusVM);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Bus.GetAll(includeProperties:"TipBusa,Kompanija") });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Bus.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });

            }
            _unitOfWork.Bus.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true,message=StaticData.SuccessMessage });

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
