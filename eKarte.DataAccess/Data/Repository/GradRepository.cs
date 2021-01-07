using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class GradRepository : Repository<Grad>, IGradRepository
    {
        private readonly ApplicationDbContext _db;
        public GradRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListForDropdown()
        {
            return _db.Grad.Select(i => new SelectListItem()
            {
                Text = i.Naziv,
                Value = i.Id.ToString()
            });
        }
        public void Update(Grad grad)
        {
            var objFromDb = _db.Grad.FirstOrDefault(i => i.Id == grad.Id);
            objFromDb.Naziv = grad.Naziv;
            objFromDb.DrzavaId = grad.DrzavaId;
            _db.SaveChanges();
        }
    }
}
