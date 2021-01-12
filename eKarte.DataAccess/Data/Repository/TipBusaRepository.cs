using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class TipBusaRepository : Repository<TipBusa>, ITipBusaRepository
    {
        private readonly ApplicationDbContext _db;

        public TipBusaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetTipBusaListForDropDown()
        {
            return _db.TipBusa.Select(i => new SelectListItem()
            {
                Text = i.Naziv,
                Value = i.Id.ToString()
            });
        }

        public void Update(TipBusa tipbusa)
        {
            var objFromDb = _db.TipBusa.FirstOrDefault(s => s.Id == tipbusa.Id);
            objFromDb.Naziv = tipbusa.Naziv;

            _db.SaveChanges();
        }
    }
}
