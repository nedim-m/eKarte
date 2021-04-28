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
    public class OsobljeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OsobljeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public OsobljeViewModel OsobljeVM { get; set; }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Upsert(int? id)
        {
            OsobljeVM = new OsobljeViewModel()
            {

                Osoblje = new Models.Osoblje(),
                SpolLista = _unitOfWork.Spol.GetSpolListForDropDown(),
                TipOsobljaLista = _unitOfWork.TipOsoblja.GetTipOsobljaListForDropDown()
            };
            if (id != null)
            {
                OsobljeVM.Osoblje = _unitOfWork.Osoblje.Get(id.GetValueOrDefault());
            }
            return View(OsobljeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (OsobljeVM.Osoblje.Id == 0)
                {
                    OsobljeVM.Osoblje.Status = StaticData.StatusSlobodno;
                    _unitOfWork.Osoblje.Add(OsobljeVM.Osoblje);
                    
                }
                else
                {
                    _unitOfWork.Osoblje.Update(OsobljeVM.Osoblje);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                OsobljeVM.SpolLista = _unitOfWork.Spol.GetSpolListForDropDown();
                OsobljeVM.TipOsobljaLista = _unitOfWork.TipOsoblja.GetTipOsobljaListForDropDown();
                return View(OsobljeVM);
            }

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Osoblje.GetAll(includeProperties: "TipOsoblja,Spol") });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.Osoblje.Get(id);
            if (obj == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });
            }
            _unitOfWork.Osoblje.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = StaticData.SuccessMessage });
        }

    }
}
