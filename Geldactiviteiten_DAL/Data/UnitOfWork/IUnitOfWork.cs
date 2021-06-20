using Geldactiviteiten_DAL.Data.Repositories;
using Geldactiviteiten_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldactiviteiten_DAL.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Doel> DoelRepo { get; }
        IRepository<Doelpubliek> DoelpubliekRepo { get; }
        IRepository<Geldactiviteit> GeldactiviteitRepo { get; }
        IRepository<Geldactiviteit_Doel> Geldactiviteit_DoelRepo { get; }
        IRepository<Geldactiviteit_Doelpubliek> Geldactiviteit_DoelpubliekRepo { get; }
        IRepository<Soort> SoortRepo { get; }
        IRepository<Tijdstip> TijdstipRepo { get; }

        IRepository<Geldactiviteit_Tijdstip> Geldactiviteit_TijdstipRepo { get; }
        int Save();
    }
}
