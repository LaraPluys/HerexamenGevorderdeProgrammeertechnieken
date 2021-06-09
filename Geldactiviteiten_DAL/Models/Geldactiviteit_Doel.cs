using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geldactiviteiten_DAL.Models
{
    public class Geldactiviteit_Doel
    {
        public int Geldactiviteit_DoelId { get; set; }
        public Doel Doel { get; set; }
        public int DoelId { get; set; }
        public Geldactiviteit Geldactiviteit { get; set; }
        public int GeldactiviteitId { get; set; }
    }
}
