using Geldactiviteiten_DAL.Data.Repositories;
using Geldactiviteiten_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldactiviteiten_DAL.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Doel> _doelRepo;
        private IRepository<Doelpubliek> _doelpubliekRepo;
        private IRepository<Geldactiviteit> _geldactiviteitRepo;
        private IRepository<Geldactiviteit_Doel> _geldactiviteit_doelRepo;
        private IRepository<Geldactiviteit_Doelpubliek> _geldactiviteit_doelpubliekRepo;
        private IRepository<Soort> _soortRepo;
        private IRepository<Tijdstip> _tijdstipRepo;
        private IRepository<Geldactiviteit_Tijdstip> _geldactiviteit_tijdstipRepo;

        public UnitOfWork(GeldactiviteitEntities geldactiviteitEntities)
        {
            this.GeldactiviteitEntities = geldactiviteitEntities;
        }

        private GeldactiviteitEntities GeldactiviteitEntities { get; }

        public IRepository<Doel> DoelRepo
        {
            get
            {
                if (_doelRepo == null)
                {
                    _doelRepo = new Repository<Doel>(this.GeldactiviteitEntities);
                }
                return _doelRepo;
            }
        }

        public IRepository<Doelpubliek> DoelpubliekRepo
        {
            get
            {
                if (_doelpubliekRepo == null)
                {
                    _doelpubliekRepo = new Repository<Doelpubliek>(this.GeldactiviteitEntities);
                }
                return _doelpubliekRepo;
            }
        }

        public IRepository<Geldactiviteit> GeldactiviteitRepo
        {
            get
            {
                if (_geldactiviteitRepo == null)
                {
                    _geldactiviteitRepo = new Repository<Geldactiviteit>(this.GeldactiviteitEntities);
                }
                return _geldactiviteitRepo;
            }
        }

        public IRepository<Geldactiviteit_Doel> Geldactiviteit_DoelRepo
        {
            get
            {
                if (_geldactiviteit_doelRepo == null)
                {
                    _geldactiviteit_doelRepo = new Repository<Geldactiviteit_Doel>(this.GeldactiviteitEntities);
                }
                return _geldactiviteit_doelRepo;
            }
        }

        public IRepository<Geldactiviteit_Doelpubliek> Geldactiviteit_DoelpubliekRepo
        {
            get
            {
                if (_geldactiviteit_doelpubliekRepo == null)
                {
                    _geldactiviteit_doelpubliekRepo = new Repository<Geldactiviteit_Doelpubliek>(this.GeldactiviteitEntities);
                }
                return _geldactiviteit_doelpubliekRepo;
            }
        }

        public IRepository<Soort> SoortRepo
        {
            get
            {
                if (_soortRepo == null)
                {
                    _soortRepo = new Repository<Soort>(this.GeldactiviteitEntities);
                }
                return _soortRepo;
            }
        }

        public IRepository<Tijdstip> TijdstipRepo
        {
            get
            {
                if (_tijdstipRepo == null)
                {
                    _tijdstipRepo = new Repository<Tijdstip>(this.GeldactiviteitEntities);
                }
                return _tijdstipRepo;
            }
        }

        public IRepository<Geldactiviteit_Tijdstip> Geldactiviteit_TijdstipRepo
        {
            get
            {
                if (_geldactiviteit_tijdstipRepo == null)
                {
                    _geldactiviteit_tijdstipRepo = new Repository<Geldactiviteit_Tijdstip>(GeldactiviteitEntities);
                }
                return _geldactiviteit_tijdstipRepo;
            }
        }

        public void Dispose()
        {
            GeldactiviteitEntities.Dispose();
        }

        public int Save()
        {
            return GeldactiviteitEntities.SaveChanges();
        }

    }
}
