using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class LinijaRepository : Repository<Linija>, ILinijaRepository
    {
        private readonly ApplicationDbContext _db;
        public LinijaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Linija Linija)
        {
            var objFromDb = _db.Linija.FirstOrDefault(i => i.Id == Linija.Id);
            objFromDb.KondukterId = Linija.KondukterId;
            objFromDb.Vozac1Id = Linija.Vozac1Id;
            objFromDb.Vozac2Id = Linija.Vozac2Id;
            objFromDb.Naziv = Linija.Naziv;
            objFromDb.OsnovnaCijenaLinije = Linija.OsnovnaCijenaLinije;
            objFromDb.BusId = Linija.BusId;
            _db.SaveChanges();
        }
    }
}
