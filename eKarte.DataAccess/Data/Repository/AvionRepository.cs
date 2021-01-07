using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class AvionRepository:Repository<Avion>,IAvionRepository
    {
        private readonly ApplicationDbContext _db;
        public AvionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListForDropdown()
        {
            return _db.Avion.Select(i => new SelectListItem()
            {
                Text = i.Naziv,
                Value = i.Id.ToString()
            });
        }
        public void Update(Avion avion)
        {
            var objFromDb = _db.Avion.FirstOrDefault(i => i.Id == avion.Id);
            objFromDb.Naziv = avion.Naziv;
            objFromDb.Kapacitet = avion.Kapacitet;
            objFromDb.KompanijaId = avion.KompanijaId;
            objFromDb.Proizvodjac = avion.Proizvodjac;
            objFromDb.Model = avion.Model;
            objFromDb.GodinaProizvodnje = avion.GodinaProizvodnje;
            _db.SaveChanges();
        }

    }
}
