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
        public Doelpubliek Doelpubliek { get; set; }
        public int DoelpubliekId { get; set; }
        public Geldactiviteit Geldactiviteit { get; set; }
        public int GeldactiviteitId { get; set; }
    }
}
