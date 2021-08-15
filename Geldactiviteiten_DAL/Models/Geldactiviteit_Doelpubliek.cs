using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldactiviteiten_DAL.Models
{
   public class Geldactiviteit_Doelpubliek
    {
        public int Geldactiviteit_DoelpubliekId { get; set; }

        public int DoelpubliekId { get; set; }

        public int GeldactiviteitId { get; set; }

        public virtual Doelpubliek Doelpubliek { get; set; }

        public virtual Geldactiviteit Geldactiviteit { get; set; }
    }
}
