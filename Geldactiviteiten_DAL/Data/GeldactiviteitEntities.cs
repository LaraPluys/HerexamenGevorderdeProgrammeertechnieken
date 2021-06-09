using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geldactiviteiten_DAL.Models;
using System.Data.Entity;

using System.Threading.Tasks;

namespace Geldactiviteiten_DAL.Data
{
    public class GeldactiviteitEntities : DbContext
    {
        public GeldactiviteitEntities() : base("name=GeldactiviteitDbConnectionString")
        {

        }

        public DbSet<Doel> Doelen { get; set; }
        public DbSet<Geldactiviteit_Doel> Geldactiviteit_Doelen { get; set; }
        public DbSet<Doelpubliek> Doelpublieken { get; set; }
        public DbSet<Geldactiviteit_Doelpubliek> Geldactiviteit_Doelpublieken { get; set; }
        public DbSet<Geldactiviteit> Geldactiviteiten { get; set; }
        public DbSet<Tijdstip> Tijdstippen { get; set; }
        public DbSet<Geldactiviteit_Tijdstip> Geldactiviteit_Tijdstippen { get; set; }
        public DbSet<Soort> Soorten { get; set; }
    }
}
