using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class OsobljeRepository : Repository<Osoblje>, IOsobljeRepository
    {
        private readonly ApplicationDbContext _db;
        public OsobljeRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(Osoblje osoblje)
        {
            var obj = _db.Osoblje.FirstOrDefault(i => i.Id == osoblje.Id);
            obj.Ime = osoblje.Ime;
            obj.Prezime = osoblje.Prezime;
            obj.SpolId = osoblje.SpolId;
            obj.TipOsobljaId = osoblje.TipOsobljaId;
            obj.Telefon = osoblje.Telefon;
            obj.JMBG = osoblje.JMBG;
            obj.DatumRodjenja = osoblje.DatumRodjenja;
            obj.DatumZaposljenja = osoblje.DatumZaposljenja;
            obj.Adresa = osoblje.Adresa;
            obj.Email = osoblje.Email;
            _db.SaveChanges();
        }

        
    }
}
