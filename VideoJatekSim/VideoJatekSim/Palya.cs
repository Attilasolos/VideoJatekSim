using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoJatekSim
{
    internal class Palya
    {
       public List<Targyak> falusi_piac { get; set; }

        public List<Targyak> varosi_piac { get; set; }

        public Palya()
        {
            falusi_piac = new List<Targyak>() { };
            varosi_piac = new List<Targyak>() { };
        }
    }
}
