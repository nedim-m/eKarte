using eKarte.DataAccess.Data.Repository.IRepository;
using eKarte.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.DataAccess.Data.Repository
{
    public class DetaljiLetaRepository:Repository<DetaljiLeta>,IDetaljiLetaRepository
    {
        private readonly ApplicationDbContext _db;

        public DetaljiLetaRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

       
    }
}
