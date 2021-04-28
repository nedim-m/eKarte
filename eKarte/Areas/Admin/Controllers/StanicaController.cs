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
    public class StanicaController : Controller
    {
       private readonly IUnitOfWork _unitOfWork;
        public StanicaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public StanicaViewModel StanicaVM { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            StanicaVM = new StanicaViewModel()
            {
                Stanica = new Models.Stanica(),
                GradList = _unitOfWork.Grad.GetListForDropdown()

            };
            if (id != null)
            {
                StanicaVM.Stanica = _unitOfWork.Stanica.Get(id.GetValueOrDefault());
            }
            return View(StanicaVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (StanicaVM.Stanica.Id == 0)
                {
                    _unitOfWork.Stanica.Add(StanicaVM.Stanica);
                }
                else
                {
                    _unitOfWork.Stanica.Update(StanicaVM.Stanica);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                StanicaVM.GradList = _unitOfWork.Grad.GetListForDropdown();

                return View(StanicaVM);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Stanica.GetAll(includeProperties: "Grad") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Stanica.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });
            }
            _unitOfWork.Stanica.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = StaticData.SuccessMessage });
        }

    }
}
