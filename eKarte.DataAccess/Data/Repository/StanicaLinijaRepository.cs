using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
   public class StanicaLinijaRepository:Repository<StanicaLinija>,IStanicaLinijaRepository
    {
        private readonly ApplicationDbContext _db;
        public StanicaLinijaRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
    }
}
