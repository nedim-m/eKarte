using eKarte.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.DataAccess.Data.Repository.IRepository
{
    public interface ILetRepository:IRepository<Let>
    {
        void Update(Let let);
    }
}
