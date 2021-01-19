using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class TipKarteRepository : Repository<TipKarte>, ITipKarteRepository
    {
        private readonly ApplicationDbContext _db;

        public TipKarteRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        
        public IEnumerable<SelectListItem> GetTipKarteListForDropDown()
        {
            return _db.TipKarte.Select(i => new SelectListItem()
            {
                Text = i.Naziv,
                Value = i.Id.ToString()
            });
        }
    }
}
