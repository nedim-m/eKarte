using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class StanicaRepository : Repository<Stanica>, IStanicaRepository
    {
        private readonly ApplicationDbContext _db;

        public StanicaRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(Stanica stanica)
        {
            var obj = _db.Stanica.FirstOrDefault(i => i.Id == stanica.Id);
            obj.Naziv = stanica.Naziv;
            obj.Telefon = stanica.Telefon;
            obj.Adresa = stanica.Adresa;
            obj.GradId = stanica.GradId;
            _db.SaveChanges();
        }
    }
}
