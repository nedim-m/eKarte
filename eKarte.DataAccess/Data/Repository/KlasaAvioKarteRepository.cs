using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class KlasaAvioKarteRepository : Repository<KlasaAvioKarte>, IKlasaAvioKarteRepository
    {
        private readonly ApplicationDbContext _db;
        public KlasaAvioKarteRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        
        public IEnumerable<SelectListItem> GetAvioKlasaKarteListForDropdown()
        {
            return _db.KlasaAvioKarte.Select(i => new SelectListItem()
            {
                Text = i.Naziv,
                Value=i.Id.ToString()
            });
        }

        public void Update(KlasaAvioKarte klasaAvioKarte)
        {
            var obj = _db.KlasaAvioKarte.FirstOrDefault(i => i.Id == klasaAvioKarte.Id);

            obj.Naziv = klasaAvioKarte.Naziv;
            obj.Hrana = klasaAvioKarte.Hrana;
            obj.MjestoDoProzora = klasaAvioKarte.MjestoDoProzora;
            obj.PortZaPunjenjeUredjaja = klasaAvioKarte.PortZaPunjenjeUredjaja;
            obj.PosebnoSjediste = klasaAvioKarte.PosebnoSjediste;
            obj.WiFi = klasaAvioKarte.WiFi;
            _db.SaveChanges();
        }
    }
}
