using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldactiviteiten_DAL.Models
{
    public class Doel
    {
        public int DoelId { get; set; }
        public string Naam { get; set; }

        public ICollection<Geldactiviteit_Doel> Geldactiviteit_Doelen { get; set; }
    }
}
