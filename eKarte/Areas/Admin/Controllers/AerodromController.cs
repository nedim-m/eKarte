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

namespace eKarte.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticData.Admin)]
    public class AerodromController:Controller
    { 
    private readonly IUnitOfWork _unitOfWork;
        public AerodromController(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public AerodromViewModel AerodromVM { get; set; }

        public IActionResult Upsert(int? id)
        {
            AerodromVM = new AerodromViewModel()
            {
                Aerodrom = new Models.Aerodrom(),
                ListaGradova=_unitOfWork.Grad.GetListForDropdown()
                
            };
            if (id != null)
            {
                AerodromVM.Aerodrom = _unitOfWork.Aerodrom.Get(id.GetValueOrDefault());
            }
            return View(AerodromVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (AerodromVM.Aerodrom.Id == 0)
                {
                    _unitOfWork.Aerodrom.Add(AerodromVM.Aerodrom);
                }
                else
                {
                    _unitOfWork.Aerodrom.Update(AerodromVM.Aerodrom);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                AerodromVM.ListaGradova = _unitOfWork.Grad.GetListForDropdown();
                
                return View(AerodromVM);
            }
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Aerodrom.GetAll(includeProperties:"Grad") });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Aerodrom.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Aerodrom.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successfull." });
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}
