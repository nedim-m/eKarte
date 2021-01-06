using System;
using System.Collections.Generic;
using System.Text;
using eKarte.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eKarte.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Spol> Spol { get; set; }
        public DbSet<TipOsoblja> TipOsoblja { get; set; }
        public DbSet<Osoblje> Osoblje { get; set; }
    }
}
