using eKarte.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.DataAccess.Data.Repository.IRepository
{
    public interface IBusRepository:IRepository<Bus>
    {
        public IEnumerable<SelectListItem> GetListForDropdown();
        public void Update(Bus Bus);
    }
}
