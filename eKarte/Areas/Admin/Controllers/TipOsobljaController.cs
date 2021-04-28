using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
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
    public class TipOsobljaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TipOsobljaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            TipOsoblja tiposoblja = new TipOsoblja();
            if (id == null)
            {
                return View(tiposoblja);
            }
            tiposoblja = _unitOfWork.TipOsoblja.Get(id.GetValueOrDefault());
            if (tiposoblja == null)
            {
                return NotFound();
            }
            return View(tiposoblja);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TipOsoblja tipOsoblja)
        {
            if (ModelState.IsValid)
            {
                if (tipOsoblja.Id == 0)
                {
                    _unitOfWork.TipOsoblja.Add(tipOsoblja);
                }
                else
                {
                    _unitOfWork.TipOsoblja.Update(tipOsoblja);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(tipOsoblja);
           
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.TipOsoblja.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.TipOsoblja.Get(id);
            if (obj == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });
            }
            _unitOfWork.TipOsoblja.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = StaticData.SuccessMessage });
        }
    }
}
