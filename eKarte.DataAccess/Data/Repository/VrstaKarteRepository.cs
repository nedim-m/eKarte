using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class VrstaKarteRepository : Repository<VrstaKarte>, IVrstaKarteRepository
    {
        private readonly ApplicationDbContext _db;
        public VrstaKarteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetVrstaKarteListForDropdown()
        {
            return _db.VrstaKarte.Select(i => new SelectListItem()
            {
                Text = i.Naziv,
                Value = i.Id.ToString()
            });

        }
        public void Update(VrstaKarte vrstaKarte)
        {
            var objFromDb = _db.VrstaKarte.FirstOrDefault(i => i.Id == vrstaKarte.Id);
            objFromDb.Naziv = vrstaKarte.Naziv;
            objFromDb.Popust = vrstaKarte.Popust;
            _db.SaveChanges();
        }

    }
}
