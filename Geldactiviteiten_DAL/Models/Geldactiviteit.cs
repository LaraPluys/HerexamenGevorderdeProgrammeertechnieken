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
        public Geldactiviteit()
        {
            Geldactiviteit_Doel = new HashSet<Geldactiviteit_Doel>();
            Geldactiviteit_Doelpubliek = new HashSet<Geldactiviteit_Doelpubliek>();
            Geldactiviteit_Tijdstip = new HashSet<Geldactiviteit_Tijdstip>();
        }


        public int GeldactiviteitId { get; set; }

        public string Naam { get; set; }
        public string Omschrijving { get; set; }

        public string ToDo { get; set; }

        public string Wanneer { get; set; }

        public string Kosten { get; set; }

        public string Inkomsten { get; set; }

        public int SoortId { get; set; }
        public virtual ICollection<Geldactiviteit_Doel> Geldactiviteit_Doel { get; set; }
        public virtual ICollection<Geldactiviteit_Doelpubliek> Geldactiviteit_Doelpubliek { get; set; }

        public virtual ICollection<Geldactiviteit_Tijdstip> Geldactiviteit_Tijdstip { get; set; }

        public virtual Soort Soort { get; set; }


    }
}
