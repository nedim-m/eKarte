using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class DrzavaRepository : Repository<Drzava>, IDrzavaRepository
    {
        private readonly ApplicationDbContext _db;
        public DrzavaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListForDropdown()
        {
            return _db.Drzava.Select(i => new SelectListItem()
            {
                Text = i.Naziv,
                Value = i.Id.ToString()
            });
        }
        public void Update(Drzava drzava)
        {
            var objFromDb = _db.Drzava.FirstOrDefault(i => i.Id == drzava.Id);
            objFromDb.Naziv = drzava.Naziv;
            _db.SaveChanges();
        }
    }
}
