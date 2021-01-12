using eKarte.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.DataAccess.Data.Repository.IRepository
{
   public interface IStanicaRepository : IRepository<Stanica>
    {
        void Update(Stanica stanica);
    }
}
