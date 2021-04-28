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
    public class StanicaLinijaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private static int temp;

        [BindProperty]
        public StanicaLinijaViewModel StanicaLinijaVM { get; set; }

        public StanicaLinijaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            StanicaLinijaVM = new StanicaLinijaViewModel();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Insert(int id)
        {
            temp = id;
           
            StanicaLinijaVM.Linija = _unitOfWork.Linija.GetFirstOrDefault(includeProperties: "StanicaPocetna,StanicaPocetna.Grad,StanicaZadnja,StanicaZadnja.Grad", filter: i => i.Id == temp);
            StanicaLinijaVM.StanicaLista = _unitOfWork.Stanica.GetStanicaListForDropDown();
     


            return View(StanicaLinijaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert()
        {
            if (ModelState.IsValid)
            {
        
                StanicaLinija stanicalinija = new StanicaLinija()
                {
                    Linija =_unitOfWork.Linija.Get(temp),
                    StanicaPolazisteId = StanicaLinijaVM.StanicaPolaskaId,
                    StanicaOdredisteId = StanicaLinijaVM.StanicaDolaskaId,
                    PolazakVrijeme = StanicaLinijaVM.PolazakVrijeme,
                    DolazakVrijeme = StanicaLinijaVM.DolazakaVrijeme,
                    Cijena = StanicaLinijaVM.OsnovnaCijenaLinije
                };
                _unitOfWork.StanicaLinija.Add(stanicalinija);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Insert));
            }
            else
            {
                StanicaLinijaVM.Linija = _unitOfWork.Linija.GetFirstOrDefault(includeProperties: "StanicaPocetna,StanicaPocetna.Grad,StanicaZadnja,StanicaZadnja.Grad", filter: i => i.Id == temp);
                StanicaLinijaVM.StanicaLista = _unitOfWork.Stanica.GetStanicaListForDropDown();
                
            }

            return View(StanicaLinijaVM);

        }

        [HttpGet]
        public IActionResult GetAllStanicaNaLiniji()
        {
            return Json(new { data = _unitOfWork.StanicaLinija.GetAll(includeProperties: "Linija,StanicaPolaziste,StanicaPolaziste.Grad,StanicaOdrediste,StanicaOdrediste.Grad", filter: i => i.LinijaId == temp)});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.StanicaLinija.Get(id);
            if (obj == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });
            }
            _unitOfWork.StanicaLinija.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = StaticData.SuccessMessage });
        }

    }
}
