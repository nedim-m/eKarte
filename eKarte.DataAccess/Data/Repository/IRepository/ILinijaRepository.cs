using eKarte.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.DataAccess.Data.Repository.IRepository
{
    public interface ILinijaRepository : IRepository<Linija>
    {
        public void Update(Linija Linija);
    }
}
