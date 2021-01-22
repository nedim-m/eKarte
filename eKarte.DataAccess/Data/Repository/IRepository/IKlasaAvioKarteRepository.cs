using eKarte.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.DataAccess.Data.Repository.IRepository
{
   public interface IKlasaAvioKarteRepository:IRepository<KlasaAvioKarte>
    {
        void Update(KlasaAvioKarte klasaAvioKarte);
        IEnumerable<SelectListItem> GetAvioKlasaKarteListForDropdown();
    }
}
