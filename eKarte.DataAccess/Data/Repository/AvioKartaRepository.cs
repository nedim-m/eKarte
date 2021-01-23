using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
   public class AvioKartaRepository:Repository<AvioKarta>,IAvioKartaRepository
    {
        private readonly ApplicationDbContext _db;
        public AvioKartaRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
    }
}
