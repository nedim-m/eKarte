using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using eKarte.Models.ViewModels;
using eKarte.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKarte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DetaljiLetaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public DetaljiLetaViewModel DetaljiLetaVM { get; set; }
        private static int temp = 0;
      
        public DetaljiLetaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            DetaljiLetaVM = new DetaljiLetaViewModel()
            {
                Let = new Let(),

                Osoblje = new Osoblje()
            };

        }


        public IActionResult Index(int id)
        {


            DetaljiLetaVM.Let = _unitOfWork.Let.Get(id);

            temp = id;

            return View(DetaljiLetaVM);
        }

        [HttpPost]
        public IActionResult Upsert(int id)
        {
            int brojac = _unitOfWork.DetaljiLeta.GetAll(includeProperties: "Let,Osoblje", filter: o => o.LetId == temp).Count();
            if (brojac>=5)
            {
                return Json(new { success = false, message = StaticData.ErrorAdd });
            }
            var obj = _unitOfWork.Osoblje.Get(id);

            DetaljiLeta detaljiLeta = new DetaljiLeta()
            {
                OsobljeId = id,
                LetId = temp

            };


            obj.Status = StaticData.StatusZauzeto;
            _unitOfWork.DetaljiLeta.Add(detaljiLeta);
            brojac++;
            _unitOfWork.Save();
            return Json(new { success = true, message = StaticData.SuccessAdd });
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Osoblje.GetAll(includeProperties: "TipOsoblja,Spol", filter: o => o.Status == StaticData.StatusSlobodno) });
        }

        [HttpGet]
        public IActionResult GetAllNaLetu()
        {
            var objFromDb = _unitOfWork.DetaljiLeta.GetAll(includeProperties: "Let,Osoblje", filter: o => o.LetId == temp);
            var obj = objFromDb.Where(i => i.Osoblje.Status == StaticData.StatusZauzeto);
           
            return Json(new { data = obj });


        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var objFromDb = _unitOfWork.DetaljiLeta.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });
            }
            else
            {
                 
               var osoba= _unitOfWork.Osoblje.Get(objFromDb.OsobljeId);
               osoba.Status = StaticData.StatusSlobodno;
               _unitOfWork.DetaljiLeta.Remove(objFromDb);
               _unitOfWork.Save();
               return Json(new { success = true, message = StaticData.SuccessMessage });
            }
           


        }

    }
}
