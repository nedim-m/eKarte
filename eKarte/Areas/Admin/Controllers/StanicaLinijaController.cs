using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using eKarte.Models.ViewModels;
using eKarte.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKarte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StanicaLinijaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private static int temp=-1;
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

        public IActionResult Upsert(int id)
        {
            var stanice = _unitOfWork.StanicaLinija.GetAll(includeProperties: "Stanica", filter: i => i.LinijaId == id);
            List<Stanica> postojeceStanice = new List<Stanica>();
            foreach (var i in stanice)
            {
                postojeceStanice.Add(i.Stanica);
            }

            var ListaZadodavanje = _unitOfWork.Stanica.GetAll().Except(postojeceStanice);
            temp = id;
            var broj = _unitOfWork.StanicaLinija.GetAll(filter: i => i.LinijaId == temp).Count();
            if (broj != 0)
            {
                StanicaLinijaVM.Linija = _unitOfWork.Linija.Get(temp);
                StanicaLinijaVM.StanicaLista = ListaZadodavanje.Select(i => new SelectListItem() { Text = i.Naziv, Value = i.Id.ToString() });
            }
            else
            {

                StanicaLinijaVM.Linija = _unitOfWork.Linija.Get(temp);
                StanicaLinijaVM.StanicaLista = _unitOfWork.Stanica.GetStanicaListForDropDown();
            }
           
       
            return View(StanicaLinijaVM);
         
          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
           
            
            if (ModelState.IsValid)
            {
                StanicaLinija stanicaLinija = new StanicaLinija()
                {
                    Linija= _unitOfWork.Linija.Get(temp),
                    Stanica = _unitOfWork.Stanica.Get(StanicaLinijaVM.StanicaId),
                    DolazakaVrijeme = StanicaLinijaVM.DolazakaVrijeme
                    
                };
              
                _unitOfWork.StanicaLinija.Add(stanicaLinija);
                
                _unitOfWork.Save();
                return RedirectToAction(nameof(Upsert));
            }
            else
            {
                StanicaLinijaVM = new StanicaLinijaViewModel()
                {
                    Linija = _unitOfWork.Linija.Get(temp),
                    StanicaLista = _unitOfWork.Stanica.GetStanicaListForDropDown()

                };

                return View(StanicaLinijaVM);
            }
        }
        [HttpGet]
        public IActionResult GetAllStanicaNaLiniji()
        {
            return Json(new { data = _unitOfWork.StanicaLinija.GetAll(includeProperties: "Stanica,Linija,Stanica.Grad",filter:i=>i.LinijaId==temp) });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var objFromDb = _unitOfWork.StanicaLinija.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = StaticData.ErrorMessage });
            }
            else
            {

                _unitOfWork.StanicaLinija.Remove(objFromDb);
                _unitOfWork.Save();
                
                return Json(new { success = true, message = StaticData.SuccessMessage });
                
            }



        }

    }
}
