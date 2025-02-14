using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoJatekSim
{
    internal class Ellenseg
    {
        public int Eletero {  get; set; }
        public int Tamadas {  get; set; }
        public int Fokozat {  get; set; }
        public int Poz { get; set; }
       
        public int Csata(Jatekos player) 
        {
            if (player.Eletero <= Tamadas)
            {
                return 0;
            }
            if (player.Tamadas < Eletero && player.Eletero > Tamadas)
            {
                if (player.Eletero < Tamadas * 2)
                {
                    return 0;
                }
                if (player.Tamadas * 2 < Eletero && player.Eletero > Tamadas * 2)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }

    }
}
