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
    public class TipBusaController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork;

        public TipBusaController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
          
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            TipBusa tipbusa = new TipBusa();
            if (id == null)
            {
                return View(tipbusa);
            }
            tipbusa = _unitOfWork.TipBusa.Get(id.GetValueOrDefault());
            if (tipbusa == null)
            {
                return NotFound();
            }
            return View(tipbusa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TipBusa tipbusa)
        {
            if (ModelState.IsValid)
            {
                if (tipbusa.Id == 0)
                {
                    _unitOfWork.TipBusa.Add(tipbusa);
                }
                else
                {
                    _unitOfWork.TipBusa.Update(tipbusa);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }


            return View(tipbusa);

        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {

            return Json(new { data = _unitOfWork.TipBusa.GetAll() });


        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.TipBusa.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });
            }
            _unitOfWork.TipBusa.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = StaticData.SuccessMessage});
        }
        #endregion
    }
}
