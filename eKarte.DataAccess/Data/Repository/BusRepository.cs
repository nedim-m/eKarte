using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class BusRepository:Repository<Bus>,IBusRepository
    {
        private readonly ApplicationDbContext _db;
        public BusRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListForDropdown()
        {
            return _db.Bus.Select(i => new SelectListItem()
            {
                Text = i.Naziv,
                Value=i.Id.ToString()
            });
        }
        public void Update(Bus Bus)
        {
            var objFromDb = _db.Bus.FirstOrDefault(i => i.Id == Bus.Id);
            objFromDb.Naziv = Bus.Naziv;
            objFromDb.Model = Bus.Model;
            objFromDb.Proizvodjac = Bus.Proizvodjac;
            objFromDb.GodinaProizvodnje = Bus.GodinaProizvodnje;
            objFromDb.Kapacitet = Bus.Kapacitet;
            objFromDb.KompanijaId = Bus.KompanijaId;
            objFromDb.TipBusaId = Bus.TipBusaId;
            _db.SaveChanges();
        }
    }
}
