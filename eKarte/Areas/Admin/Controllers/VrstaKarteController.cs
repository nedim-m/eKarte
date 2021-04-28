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
    public class VrstaKarteController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public VrstaKarteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            VrstaKarte vrstaKarte = new VrstaKarte();
            if (id == null)
            {
                return View(vrstaKarte);
            }
            vrstaKarte = _unitOfWork.VrstaKarte.Get(id.GetValueOrDefault());
            if (vrstaKarte == null)
            {
                return NotFound();
            }
            return View(vrstaKarte);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(VrstaKarte vrstaKarte)
        {
            if (ModelState.IsValid)
            {
                if (vrstaKarte.Id == 0)
                {
                    _unitOfWork.VrstaKarte.Add(vrstaKarte);
                }
                else
                {
                    _unitOfWork.VrstaKarte.Update(vrstaKarte);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }


            return View(vrstaKarte);

        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {

            return Json(new { data = _unitOfWork.VrstaKarte.GetAll() });


        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.VrstaKarte.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });
            }
            _unitOfWork.VrstaKarte.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = StaticData.SuccessMessage });
        }
        #endregion
    }
}
