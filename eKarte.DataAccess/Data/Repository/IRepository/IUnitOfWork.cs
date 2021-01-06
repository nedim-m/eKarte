using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.DataAccess.Data.Repository.IRepository
{
   public interface IUnitOfWork:IDisposable
    {
        ISpolRepository Spol { get; }
        ITipOsobljaRepository TipOsoblja { get; }
        IOsobljeRepository Osoblje { get; }
        IAerodromRepository Aerodrom { get; }


        void Save();
    }
}
