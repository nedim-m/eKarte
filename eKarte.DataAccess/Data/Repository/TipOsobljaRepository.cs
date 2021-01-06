using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class TipOsobljaRepository : Repository<TipOsoblja>, ITipOsobljaRepository
    {
        private readonly ApplicationDbContext _db;
        public TipOsobljaRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetTipOsobljaListForDropDown()
        {
            return _db.TipOsoblja.Select(i => new SelectListItem()
            {
                Text = i.Naziv,
                Value=i.Id.ToString()
            });
        }

        public void Update(TipOsoblja tipOsoblja)
        {
            var obj = _db.TipOsoblja.FirstOrDefault(i => i.Id == tipOsoblja.Id);
            obj.Naziv = tipOsoblja.Naziv;
            obj.Oznaka = tipOsoblja.Oznaka;
            _db.SaveChanges();
        }
    }
}
