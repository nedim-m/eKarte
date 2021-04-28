using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
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
            int brojPosade = _unitOfWork.Let.Get(temp).BrojPosadeNaletu;
            if (brojac>= brojPosade)
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
            return Json(new { data = _unitOfWork.Osoblje.GetAll(includeProperties: "TipOsoblja,Spol", filter: o => o.Status == StaticData.StatusSlobodno).Where(i=>i.TipOsoblja.Oznaka==StaticData.OznakaAvion) });
        }

        [HttpGet]
        public IActionResult GetAllNaLetu()
        {
           

            return Json(new { data = _unitOfWork.DetaljiLeta.GetAll(includeProperties: "Let,Osoblje,Osoblje.Spol,Osoblje.TipOsoblja", filter: o => o.LetId == temp).Where(i => i.Osoblje.Status == StaticData.StatusZauzeto) });
           
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
