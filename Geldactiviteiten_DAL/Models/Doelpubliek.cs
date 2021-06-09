using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldactiviteiten_DAL.Models
{
    public class Doelpubliek
    {
        public int DoelpubliekId { get; set; }

        public string Naam { get; set; }
        public ICollection<Geldactiviteit_Doelpubliek> Geldactiviteit_Doelpublieken { get; set; }
    }
}
