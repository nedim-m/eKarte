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
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Aerodrom> Aerodrom { get; set; }
        public DbSet<Let> Let { get; set; }
        public DbSet<Avion> Avion { get; set; }
        public DbSet<Kompanija> Kompanija { get; set; }
        public DbSet<DetaljiLeta> DetaljiLeta { get; set; }
        public DbSet<Stanica> Stanica { get; set; }
        public DbSet<TipBusa> TipBusa { get; set; }
        public DbSet<Bus> Bus { get; set; }
        public DbSet<Linija> Linija { get; set; }
        public DbSet<StanicaLinija> StanicaLinija { get; set; }
        public DbSet<TipKarte> TipKarte { get; set; }
        public DbSet<VrstaKarte> VrstaKarte { get; set; }
        public DbSet<KlasaAvioKarte> KlasaAvioKarte { get; set; }
        public DbSet<AvioKarta> AvioKarta { get; set; }
        public DbSet<AutobusnaKarta> AutobusnaKarta { get; set; }

    }
}
