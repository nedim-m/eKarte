using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using eKarte.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eKarte.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticData.Admin)]
    public class DrzavaController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public DrzavaController(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }
        public IActionResult Upsert(int? id)
        {
            Drzava drzava = new Drzava();
            if (id == null)
            {
                return View(drzava);
            }
            drzava = _unitOfWork.Drzava.Get(id.GetValueOrDefault());
            if (drzava == null)
            {
                return NotFound();
            }
            return View(drzava);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Drzava drzava)
        {
            if (ModelState.IsValid)
            {
                if (drzava.Id == 0)
                {
                    _unitOfWork.Drzava.Add(drzava);
                }
                else
                {
                    _unitOfWork.Drzava.Update(drzava);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(drzava);
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Drzava.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Drzava.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });
            }
            _unitOfWork.Drzava.Remove(objFromDb);
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
