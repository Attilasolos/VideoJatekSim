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
        public int PozSzam { get; set; }
        public int Penc { get; set; }
        public int Karizma { get; set; }
        public bool Vege { get; set; }
        public bool Gyozott { get; set; }
        public int LepesSzam { get; set; }
        Ellenseg Reszeg_Paraszt_Bottal = new Ellenseg() { Eletero = 70, Tamadas = 30, Fokozat = 1 };
        Ellenseg Paraszt = new Ellenseg() { Eletero = 100, Tamadas = 40, Fokozat = 2 };
        Ellenseg Alap_Bandita = new Ellenseg() { Eletero = 150, Tamadas = 110, Fokozat = 3 };
        Ellenseg Magasan_Kepzett_Bandita = new Ellenseg() { Eletero = 190, Tamadas = 160, Fokozat = 4 };
        Ellenseg Makvratr = new Ellenseg() { Eletero = 400, Tamadas = 200, Fokozat = 5 };

        Palya Telepules = new Palya();
        public string Vasarlas(Palya Telepules)
        {
            if (PozSzam == 2)
            {
                Telepules.PiacMegjelenit(2);
                Console.Write("Melyik tárgyat szeretnéd megvásárolni? (Az áru árát nem adjuk vissza) ");
                int vasarolni_kivant_targy = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (Penc >= Telepules.falusi_piac[vasarolni_kivant_targy -1].Ar)
                {
                    Penc -= Telepules.falusi_piac[vasarolni_kivant_targy].Ar;
                    if (Eletero + Telepules.falusi_piac[vasarolni_kivant_targy].Gyogyitas < 100)
                    {
                        Eletero += Telepules.falusi_piac[vasarolni_kivant_targy].Gyogyitas;
                    }
                    else if (Eletero < 100)
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
        public string Talalkozas()
        {
            Random rand = new Random();
            if (LepesSzam > 25 && PozSzam == 1)
            {
                int szerencse = rand.Next(1, 101);
                if (szerencse <= 5)
                {
                    Console.WriteLine("Ellenség támad rád");
                    int ellenseg_szint = rand.Next(1, 15);
                    if (ellenseg_szint <= 5)
                    {
                        return Csata_feldolgozas(Reszeg_Paraszt_Bottal);
                    }
                    else if (ellenseg_szint <= 9)
                    {
                        return Csata_feldolgozas(Paraszt);
                    }
                    else if (ellenseg_szint <= 12)
                    {
                        return Csata_feldolgozas(Alap_Bandita);
                    }
                    else
                    {
                        return Csata_feldolgozas(Magasan_Kepzett_Bandita);
                    }
                }
            }
            return "\nNincs találkozás\n";
        }
        public void Mozgas(ConsoleKey info)
        {
            switch (info)
            {
                case ConsoleKey.W:
                    if (Poz > 60)
                    {
                        Poz -= 60;
                    }
                    else
                    {
                        break;
                    }
                    break;
                case ConsoleKey.D:
                    if ((Poz + 1) % 60 != 0)
                    {
                        Poz += 1;
                    }
                    else
                    {
                        break;
                    }
                    break;
                case ConsoleKey.S:
                    if (Poz + 60 < terkep.Length)
                    {
                        Poz += 60;
                    }
                    else
                    {
                        break;
                    }
                    break;
                case ConsoleKey.A:
                    if ((Poz) % 60 != 0)
                    {
                        Poz -= 1;
                    }
                    else
                    {
                        break;
                    }
                    break;
            }
        }
        public string MenuSzoveg()
        {
            return "Melyik irányba haladjunk tovább?\n\tW: fel\n\tD: jobbra\n\tS: lefelé\n\tA: balra\nMerre? ";
        }
        int[] terkep =
           {
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,1,2,1,1,1,
                1,1,1,1,1,1,1,2,2,2,2,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,1,1,1,
                1,1,1,1,1,1,1,2,2,2,2,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,0,1,1,1,0,0,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,0,1,0,1,0,1,1,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,0,1,1,1,0,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,2,2,2,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,4,4,4,4,4,4,1,1,
                0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,4,4,4,4,4,4,4,4,4,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,0,1,1,1,1,1,0,1,1,1,0,1,1,1,4,4,4,4,4,4,4,4,4,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0,1,1,1,1,1,0,0,0,0,0,0,1,1,1,1,1,0,0,0,1,0,1,1,1,1,0,1,1,1,1,4,4,4,4,4,4,4,4,1,
                1,1,1,1,1,1,3,3,3,3,3,3,3,3,1,1,1,0,1,1,0,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,0,1,1,1,1,1,4,4,4,4,4,1,1,
                1,1,1,1,1,3,3,3,3,3,3,3,3,3,3,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,4,4,4,1,1,1,
                1,1,1,1,1,3,3,3,3,3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,1,1,1,1,1,1,0,
                1,1,1,1,1,3,3,3,3,3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,1,1,0,0,0,1,1,1,0,0,
                1,1,1,1,1,3,3,3,3,3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,1,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,1,1,1,0,0,0,0,0,0,
                1,1,1,1,1,1,3,3,3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,0,0,0,0,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,


            };
        public string Megerkezes(ConsoleKey info)
        {
            if ((PozSzam == 2 || PozSzam == 3))
            {
                switch (info)
                {
                    case ConsoleKey.S:
                        return "Semmit nem csináltál";
                    case ConsoleKey.V:
                        return Vasarlas(Telepules);
                    case ConsoleKey.M:
                        return Munka();
                }
            }
            return "";
        }
        public string Telepulesimenuszoveg()
        {
            if(PozSzam == 3 || PozSzam == 2)
                return "\nAkarsz-e valamit csinálni?\n\tS: Semmit\n\tV: Vásásrlás\n\tM: Munka\nMi a választásod?";
            else
            {
                return "";
            }
        }
        public void Vegso_csata()
        {

                Csata_feldolgozas(Makvratr);
                if (Csata_feldolgozas(Makvratr) == "\nNyertél\n")
                {
                    Gyozott = true;
                    Vege = true;
                }
                else if (Csata_feldolgozas(Makvratr) == "\nVesztettél\n")
                    Vege = true;
        }
        
    }
}
