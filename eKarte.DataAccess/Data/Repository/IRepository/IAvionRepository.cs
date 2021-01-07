using eKarte.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.DataAccess.Data.Repository.IRepository
{
    public interface IAvionRepository : IRepository<Avion>
    {
        IEnumerable<SelectListItem> GetListForDropdown();
        void Update(Avion avion);
    }
}
