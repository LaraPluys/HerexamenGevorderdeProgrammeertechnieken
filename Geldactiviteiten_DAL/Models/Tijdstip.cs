using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldactiviteiten_DAL.Models
{
   public class Tijdstip
    {
        public int TijdstipId { get; set; }
        public string Naam { get; set; }

        public ICollection<Geldactiviteit_Tijdstip> Geldactiviteit_Tijdstippen { get; set; }
    }
}
