using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldactiviteiten_DAL.Models
{
   public class Geldactiviteit_Tijdstip
    {
        public int Geldactiviteit_TijdstipId { get; set; }
        public Tijdstip Tijdstip { get; set; }
        public int TijdstipId { get; set; }
        public Geldactiviteit Geldactiviteit { get; set; }
        public int GeldactiviteitId { get; set; }
    }
}
