using System;
using System.Collections.Generic;
using System.Text;

namespace eKarte.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ISpolRepository Spol { get; }
        ITipOsobljaRepository TipOsoblja { get; }
        IOsobljeRepository Osoblje { get; }
        IAerodromRepository Aerodrom { get; }
        IDrzavaRepository Drzava { get; }
        IGradRepository Grad { get; }
        IKompanijaRepository Kompanija { get; }
        IAvionRepository Avion { get; }
        ILetRepository Let { get; }
        IDetaljiLetaRepository DetaljiLeta { get; }
        IStanicaRepository Stanica { get; }
        ITipBusaRepository TipBusa { get; }
        IBusRepository Bus { get; }
        ILinijaRepository Linija { get; }
        IStanicaLinijaRepository StanicaLinija { get; }
        ITipKarteRepository TipKarte { get; }
        IVrstaKarteRepository VrstaKarte { get; }
        IKlasaAvioKarteRepository KlasaAvioKarte { get; }
        IAvioKartaRepository AvioKarta { get; }
        IAutobusnaKartaRepository AutobusnaKarta { get; }
        void Save();
    }
}
