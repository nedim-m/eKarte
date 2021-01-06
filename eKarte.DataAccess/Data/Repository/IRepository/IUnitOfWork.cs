using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.DataAccess.Data.Repository.IRepository
{
   public interface IUnitOfWork:IDisposable
    {

        void Save();
    }
}
