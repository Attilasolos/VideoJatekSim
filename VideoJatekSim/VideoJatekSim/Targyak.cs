using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoJatekSim
{
    internal class Targyak
    {
        public string Nev {  get; set; }
        public int Gyogyitas { get; set; }
        public int Vedelem { get; set; }
        public int Sebzes { get; set; }
        public int Karizmatikum {  get; set; } 
        public int Ar {  get; set; }

        public Targyak(string nev, int gyogyitas, int vedelem, int sebzes, int karizma, int ar)
        {
            Nev = nev;
            Gyogyitas = gyogyitas;
            Vedelem = vedelem;
            Sebzes = sebzes;
            Karizmatikum = karizma;
            Ar = ar;
        }
    }
}
