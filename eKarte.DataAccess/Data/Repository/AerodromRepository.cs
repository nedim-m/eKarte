using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class AerodromRepository : Repository<Aerodrom>, IAerodromRepository
    {
        private readonly ApplicationDbContext _db;
        public AerodromRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetAerodromListForDropdown()
        {
            return _db.Aerodrom.Select(i => new SelectListItem()
            {
                Text = i.Naziv,
                Value = i.Id.ToString()
            });
        }
        public void Update(Aerodrom aerodrom)
        {
            var objFromDb = _db.Aerodrom.FirstOrDefault(i => i.Id == aerodrom.Id);
            objFromDb.Naziv = aerodrom.Naziv;
            objFromDb.Sifra = aerodrom.Sifra;
            objFromDb.GradId = aerodrom.GradId;
            _db.SaveChanges();
        }

    }
}
