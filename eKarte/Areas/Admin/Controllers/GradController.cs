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
    public class GradController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public GradController(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public GradViewModel GradVM { get; set; }

        public IActionResult Upsert(int? id)
        {
            GradVM = new GradViewModel()
            {
                Grad = new Models.Grad(),
                DrzavaLista = _unitOfWork.Drzava.GetListForDropdown()
                
            };
            if (id != null)
            {
                GradVM.Grad = _unitOfWork.Grad.Get(id.GetValueOrDefault());
            }
            return View(GradVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (GradVM.Grad.Id == 0)
                {
                    _unitOfWork.Grad.Add(GradVM.Grad);
                }
                else
                {
                    _unitOfWork.Grad.Update(GradVM.Grad);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                GradVM.DrzavaLista = _unitOfWork.Drzava.GetListForDropdown();
                
                return View(GradVM);
            }
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Grad.GetAll(includeProperties:"Drzava") });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Grad.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });
            }
            _unitOfWork.Grad.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = StaticData.SuccessMessage });
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}
