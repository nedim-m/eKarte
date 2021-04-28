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
    public class KlasaAvioKarteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public KlasaAvioKarteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Upsert(int? id)
        {
            KlasaAvioKarte klasaAvioKarte = new KlasaAvioKarte();
            if (id == null)
            {
                return View(klasaAvioKarte);
            }
            klasaAvioKarte = _unitOfWork.KlasaAvioKarte.Get(id.GetValueOrDefault());
            if (klasaAvioKarte == null)
            {
                return NotFound();
            }
            return View(klasaAvioKarte);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(KlasaAvioKarte klasaAvioKarte)
        {
            if (ModelState.IsValid)
            {
                if (klasaAvioKarte.Id == 0)
                {
                    _unitOfWork.KlasaAvioKarte.Add(klasaAvioKarte);
                }
                else
                {
                    _unitOfWork.KlasaAvioKarte.Update(klasaAvioKarte);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(klasaAvioKarte);

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.KlasaAvioKarte.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.KlasaAvioKarte.Get(id);
            if (obj == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });
            }
            _unitOfWork.KlasaAvioKarte.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = StaticData.SuccessMessage });
        }

    }
}
