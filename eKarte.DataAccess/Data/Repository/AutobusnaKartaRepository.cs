using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class AutobusnaKartaRepository : Repository<AutobusnaKarta>, IAutobusnaKartaRepository
    {
        private readonly ApplicationDbContext _db;
        public AutobusnaKartaRepository(ApplicationDbContext db):base(db)
            {
            _db=db;
            }
    }
}
