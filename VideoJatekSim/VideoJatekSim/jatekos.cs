using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoJatekSim
{
    internal class Jatekos
    {
        public int Eletero { get; set; }
        public int Tamadas { get; set; }
        public int Poz { get; set; }
        public int PozSzam {  get; set; }
        public int Penc { get; set; }
        Targyak targy = new Targyak();
        public int Vasarlas()
        {
            if (Penc > targy.Ar)
            {
                Penc -= targy.Ar;
                return 2;

            }
            else if (Penc > targy.Ar)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        
        public void Munka()
            {
                if (PozSzam == 2)
                {
                    Penc += 50;
                }
                else if ((PozSzam == 3) )
                {
                    Penc += 100;
                }
            else
            {
                Penc += 0;

            }
            }
    }
}
