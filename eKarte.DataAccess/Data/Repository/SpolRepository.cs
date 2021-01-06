using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class SpolRepository : Repository<Spol>, ISpolRepository
    {
        private readonly ApplicationDbContext _db;

        public SpolRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetSpolListForDropDown()
        {
            return _db.Spol.Select(i => new SelectListItem()
            {
                Text = i.Naziv,
                Value=i.Id.ToString()
            });
        }
    }
}
