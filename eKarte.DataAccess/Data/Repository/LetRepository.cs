using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class LetRepository : Repository<Let>, ILetRepository
    {
        private readonly ApplicationDbContext _db;
        public LetRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Update(Let let)
        {
            var obj = _db.Let.FirstOrDefault(i => i.Id == let.Id);
            obj.DatumLeta = let.DatumLeta;
            obj.VrijemeLeta = let.VrijemeLeta;
            obj.AerodromDoId = let.AerodromDoId;
            obj.AerodromOdId = let.AerodromOdId;
            obj.AvionId = let.AvionId;
            obj.Naziv = let.Naziv;
            obj.OsnovnaCijenaLeta = let.OsnovnaCijenaLeta;
            obj.BrojPosadeNaletu = let.BrojPosadeNaletu;
            _db.SaveChanges();

        }
    }
}
