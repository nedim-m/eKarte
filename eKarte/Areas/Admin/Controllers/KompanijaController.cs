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
    public class KompanijaController : Controller
    {
     
        
        private readonly IUnitOfWork _unitOfWork;
        public KompanijaController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public IActionResult Upsert(int? id)
        {
            Kompanija kompanija = new Kompanija();
            if (id == null)
            {
                return View(kompanija);
            }
            kompanija = _unitOfWork.Kompanija.Get(id.GetValueOrDefault());
            if (kompanija == null)
            {
                return NotFound();
            }
            return View(kompanija);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Kompanija kompanija)
        {
            if (ModelState.IsValid)
            {
                if (kompanija.Id == 0)
                {
                    _unitOfWork.Kompanija.Add(kompanija);
                }
                else
                {
                    _unitOfWork.Kompanija.Update(kompanija);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(kompanija);
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Kompanija.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Kompanija.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Kompanija.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Error while deleting" });
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}
