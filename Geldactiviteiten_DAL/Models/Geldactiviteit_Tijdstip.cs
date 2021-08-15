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

        public int TijdstipId { get; set; }

        public int GeldactiviteitId { get; set; }

        public virtual Geldactiviteit Geldactiviteit { get; set; }

        public virtual Tijdstip Tijdstip { get; set; }
    }
}
