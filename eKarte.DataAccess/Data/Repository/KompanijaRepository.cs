using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class KompanijaRepository : Repository<Kompanija>, IKompanijaRepository
    {
        private readonly ApplicationDbContext _db;
        public KompanijaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListForDropdown()
        {
            return _db.Kompanija.Select(i => new SelectListItem()
            {
                Text = i.Naziv,
                Value = i.Id.ToString()
            });
        }
        public void Update(Kompanija kompanija)
        {
            var objFromDb = _db.Kompanija.FirstOrDefault(i => i.Id == kompanija.Id);
            objFromDb.Naziv = kompanija.Naziv;
            objFromDb.Adresa = kompanija.Adresa;
            objFromDb.Telefon = kompanija.Telefon;
            _db.SaveChanges();
        }
    }
}
