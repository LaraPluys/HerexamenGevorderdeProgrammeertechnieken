using Geldactiviteiten_DAL.BasisModel;
using Geldactiviteiten_DAL.partials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldactiviteiten_DAL.Models
{
    public class Geldactiviteit : Basisklasse
    {
        public int GeldactiviteitId { get; set; }
        public string Omschrijving { get; set; }
        public string ToDo { get; set; }
        public string Wanneer { get; set; }
        public string Kosten { get; set; }
        public string Inkomsten { get; set; }

        public Soort Soort { get; set; }
        public int SoortId { get; set; }
        public ICollection<Geldactiviteit_Doel> Geldactiviteit_Doelen { get; set; }
        public ICollection<Geldactiviteit_Doelpubliek> Geldactiviteit_Doelpublieken { get; set; }

        public ICollection<Geldactiviteit_Tijdstip> Geldactiviteit_Tijdstippen { get; set; }

   
    }
}
