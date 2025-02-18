using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        public int Karizma { get; set; }
        public bool Vege { get; set; }
        public bool Gyozott { get; set; }

        public string Vasarlas(Palya Telepules)
        {
            if (PozSzam == 2)
            {
                Telepules.PiacMegjelenit(2);
                Console.Write("Melyik tárgyat szeretnéd megvásárolni? (Az áru árát nem adjuk vissza) ");
                int vasarolni_kivant_targy = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (Penc >= Telepules.falusi_piac[vasarolni_kivant_targy].Ar)
                {
                    Penc -= Telepules.falusi_piac[vasarolni_kivant_targy].Ar;
                    if(Eletero + Telepules.falusi_piac[vasarolni_kivant_targy].Gyogyitas < 100)
                    {
                        Eletero += Telepules.falusi_piac[vasarolni_kivant_targy].Gyogyitas;
                    }
                    else if(Eletero < 100)
                    {
                        Eletero = 100;
                    }
                    else
                    {
                        Eletero += 0;
                    }
                    if (Telepules.falusi_piac[vasarolni_kivant_targy].Vedelem > 0)
                    Eletero = 100 + Telepules.falusi_piac[vasarolni_kivant_targy].Vedelem;

                    if (Telepules.falusi_piac[vasarolni_kivant_targy].Sebzes > 0)
                    Tamadas = 50 + Telepules.falusi_piac[vasarolni_kivant_targy].Sebzes;

                    if (Telepules.falusi_piac[vasarolni_kivant_targy].Karizmatikum > 0)
                        Karizma = 0 + Telepules.falusi_piac[vasarolni_kivant_targy].Karizmatikum;
                    return "\nsikeres vásárlás\n";

                }
                else 
                {
                    return "\nnincs pénzed talán dolgozni kéne\n";
                }
            }
            else
            {
                Telepules.PiacMegjelenit(3);
                Console.Write("Melyik tárgyat szeretnéd megvásárolni? ");
                int vasarolni_kivant_targy = Convert.ToInt32(Console.ReadLine());
                if (Penc >= Telepules.varosi_piac[vasarolni_kivant_targy].Ar)
                {
                    Penc -= Telepules.varosi_piac[vasarolni_kivant_targy].Ar;
                    if (Eletero + Telepules.varosi_piac[vasarolni_kivant_targy].Gyogyitas < 100)
                    {
                        Eletero += Telepules.varosi_piac[vasarolni_kivant_targy].Gyogyitas;
                    }
                    else if (Eletero < 100)
                    {
                        Eletero = 100;
                    }
                    else
                    {
                        Eletero += 0;
                    }
                    if (Telepules.varosi_piac[vasarolni_kivant_targy].Vedelem > 0)
                        Eletero = 100 + Telepules.varosi_piac[vasarolni_kivant_targy].Vedelem;

                    if (Telepules.varosi_piac[vasarolni_kivant_targy].Sebzes > 0)
                        Tamadas = 50 + Telepules.varosi_piac[vasarolni_kivant_targy].Sebzes;

                    if (Telepules.varosi_piac[vasarolni_kivant_targy].Karizmatikum > 0)
                        Karizma = 0 + Telepules.varosi_piac[vasarolni_kivant_targy].Karizmatikum;

                    return "\nsikeres vásárlás\n";
                }
                else
                {
                    return "\nnincs pénzed talán dolgozni kéne\n";
                }
            }
            
        }
        
        public string Munka()
            {
                if (PozSzam == 2)
                {
                    Penc += 50;
                    return "\nSikeres munka\n";
                }
                else
                {
                    if (Karizma > 4)
                    {
                        Penc += 100;
                        return "\nSikeres munka\n";
                    }
                    else
                    {
                        Penc += 0;
                        return "\nNem néztél ki elég jól a jóembereknek\n";
                    }
                }
            }
       public string Csata_feldolgozas(Ellenseg elleseg)
        {
            elleseg.Csata(this);
            if (elleseg.Csata(this) == 0)
            {
                Vege = true;
                return "\nVesztettél\n";
            }
            else if (elleseg.Csata(this) == 1)
            {
                return "\nNyertél\n";
            }
            else
            {
                Eletero -= elleseg.Tamadas;
                return "\nDöntetlen\n";
            }
        }

        }
    }

