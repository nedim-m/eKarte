using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models.ViewModels;
using eKarte.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKarte.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticData.Admin)]
    public class LetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public LetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public LetViewModel LetVM { get; set; }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            LetVM = new LetViewModel()
            {
                Let = new Models.Let(),
                AerodromDoLista = _unitOfWork.Aerodrom.GetAerodromListForDropdown(),
                AerodromOdLista = _unitOfWork.Aerodrom.GetAerodromListForDropdown(),
                AvionLista = _unitOfWork.Avion.GetListForDropdown()
            };
            if (id != null)
            {
                LetVM.Let = _unitOfWork.Let.Get(id.GetValueOrDefault());
            }
            return View(LetVM);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (LetVM.Let.Id == 0)
                {
                    _unitOfWork.Let.Add(LetVM.Let);
                }
                else
                {
                    _unitOfWork.Let.Update(LetVM.Let);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                LetVM.AerodromDoLista = _unitOfWork.Aerodrom.GetAerodromListForDropdown();
                LetVM.AerodromOdLista = _unitOfWork.Aerodrom.GetAerodromListForDropdown();
                LetVM.AvionLista = _unitOfWork.Avion.GetListForDropdown();
                return View(LetVM);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Let.GetAll(includeProperties: "Avion,AerodromDo,AerodromOd") });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.Let.Get(id);
            if (obj == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });
            }
            _unitOfWork.Let.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = StaticData.SuccessMessage });
        }
    }
}
