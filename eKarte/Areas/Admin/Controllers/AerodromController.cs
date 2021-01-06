using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using Microsoft.AspNetCore.Mvc;

namespace eKarte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AerodromController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public AerodromController(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Aerodrom aerodrom = new Aerodrom();
            if (id == null)
            {
                return View(aerodrom);
            }
            aerodrom = _unitOfWork.Aerodrom.Get(id.GetValueOrDefault());
            if (aerodrom == null)
            {
                return NotFound();
            }
            return View(aerodrom);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Aerodrom aerodrom)
        {
            if (ModelState.IsValid)
            {
                if (aerodrom.Id == 0)
                {
                    _unitOfWork.Aerodrom.Add(aerodrom);
                }
                else
                {
                    _unitOfWork.Aerodrom.Update(aerodrom);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(aerodrom);
        }
        #region API CALLS
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Aerodrom.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Aerodrom.Get(id);
            if (objFromDb == null)
            {
                return Json(new { succes = false, message = "Error while deleting" });
            }
            _unitOfWork.Aerodrom.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successfull." });
        }
        #endregion

        
    }
}
