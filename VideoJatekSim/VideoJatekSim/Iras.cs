using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoJatekSim
{

    internal class Iras
    {
        Palya Telepules = new Palya();
        public void PiacMegjelenit(int pozSzam)
        {
            if (pozSzam == 2)
            {
                foreach (var aru in Telepules.falusi_piac)
                {
                    Console.WriteLine($"\n{aru.Nev} - Ár: {aru.Ar} pénz, Védelem: {aru.Vedelem}, Sebzés: {aru.Sebzes}, Karizma: {aru.Karizmatikum}");
                }
            }
            else if (pozSzam == 3)
            {
                foreach (var aru in Telepules.varosi_piac)
                {
                    Console.WriteLine($"\n{aru.Nev} - Ár: {aru.Ar} pénz, Védelem: {aru.Vedelem}, Sebzés: {aru.Sebzes}, Karizma: {aru.Karizmatikum}");
                }
            }
        }
        public string Vasarlas(Palya Telepules, Jatekos jatekos)
        {
            if (jatekos.PozSzam == 2)
            {
                PiacMegjelenit(2);
                Console.Write("\nMelyik tárgyat szeretnéd megvásárolni? (Az áru árát nem adjuk vissza) ");
                int vasarolni_kivant_targy = Convert.ToInt32(Console.ReadLine());
                if (vasarolni_kivant_targy - 1 < Telepules.falusi_piac.Count && vasarolni_kivant_targy > 0)
                {
                    if (jatekos.Penc >= Telepules.falusi_piac[vasarolni_kivant_targy - 1].Ar)
                    {
                        jatekos.Penc -= Telepules.falusi_piac[vasarolni_kivant_targy-1].Ar;
                        if (jatekos.Eletero + Telepules.falusi_piac[vasarolni_kivant_targy - 1].Gyogyitas < 100)
                        {
                            jatekos.Eletero += Telepules.falusi_piac[vasarolni_kivant_targy - 1].Gyogyitas;
                        }
                        else if (jatekos.Eletero < 100)
                        {
                            jatekos.Eletero = 100;
                        }
                        else
                        {
                            jatekos.Eletero += 0;
                        }
                        if (Telepules.falusi_piac[vasarolni_kivant_targy -1].Vedelem > 0)
                            jatekos.Eletero = 100 + Telepules.falusi_piac[vasarolni_kivant_targy - 1].Vedelem;

                        if (Telepules.falusi_piac[vasarolni_kivant_targy - 1].Sebzes > 0)
                            jatekos.Tamadas = 50 + Telepules.falusi_piac[vasarolni_kivant_targy - 1].Sebzes;

                        if (Telepules.falusi_piac[vasarolni_kivant_targy - 1].Karizmatikum > 0)
                            jatekos.Karizma = 0 + Telepules.falusi_piac[vasarolni_kivant_targy - 1].Karizmatikum;

                        return "\nsikeres vásárlás\n";
                    }
                    else
                    {
                        return "\nnincs pénzed talán dolgozni kéne\n";
                    }
                }
                else
                {
                    throw new Exception("\nLétező tárgyat nehéz volt választani mi?\n");
                }
            }
            else
            {
                PiacMegjelenit(3);
                Console.Write("Melyik tárgyat szeretnéd megvásárolni? (Az áru árát nem adjuk vissza) ");
                int vasarolni_kivant_targy = Convert.ToInt32(Console.ReadLine());
                if (jatekos.Penc >= Telepules.varosi_piac[vasarolni_kivant_targy -1].Ar)
                {
                    jatekos.Penc -= Telepules.varosi_piac[vasarolni_kivant_targy - 1].Ar;
                    if (jatekos.Eletero + Telepules.varosi_piac[vasarolni_kivant_targy - 1].Gyogyitas < 100)
                    {
                        jatekos.Eletero += Telepules.varosi_piac[vasarolni_kivant_targy - 1].Gyogyitas;
                    }
                    else if (jatekos.Eletero < 100)
                    {
                        jatekos.Eletero = 100;
                    }
                    else
                    {
                        jatekos.Eletero += 0;
                    }
                    if (Telepules.varosi_piac[vasarolni_kivant_targy - 1].Vedelem > 0)
                        jatekos.Eletero = 100 + Telepules.varosi_piac[vasarolni_kivant_targy - 1].Vedelem;

                    if (Telepules.varosi_piac[vasarolni_kivant_targy - 1].Sebzes > 0)
                        jatekos.Tamadas = 50 + Telepules.varosi_piac[vasarolni_kivant_targy - 1].Sebzes;

                    if (Telepules.varosi_piac[vasarolni_kivant_targy - 1].Karizmatikum > 0)
                        jatekos.Karizma = 0 + Telepules.varosi_piac[vasarolni_kivant_targy - 1 ].Karizmatikum;

                    return "\nsikeres vásárlás\n";
                }
                else
                {
                    return "\nnincs pénzed talán dolgozni kéne\n";
                }
            }

        }
        public ConsoleColor Jatekos_Eletero_szin(Jatekos jatekos)
        {
            if (jatekos.Eletero > 100)
            {
                return ConsoleColor.Blue;
            }
            else if (jatekos.Eletero > 80)
            {
                return ConsoleColor.DarkGreen;
            }
            else if (jatekos.Eletero > 60)
            {
                return ConsoleColor.Green;
            }
            else if (jatekos.Eletero > 30)
            {
                return ConsoleColor.Yellow;
            }
            else if (jatekos.Eletero > 10)
            {
                return ConsoleColor.Red;
            }
            else
            {
                return ConsoleColor.DarkRed;
            }
        }
        public List<(char, ConsoleColor)> Terkep_Letrehozas(int playerPos, int enemyPos, int lineWidth, Palya nemterkep)
        {
            var map = new List<(char, ConsoleColor)>();
            for (int index = 0; index < nemterkep.terkep.Length; index++)
            {
                if (index == playerPos)
                {
                    map.Add(('█', ConsoleColor.Yellow));
                }
                else if (index == enemyPos)
                {
                    map.Add(('█', ConsoleColor.DarkRed));
                }
                else
                {
                    switch (nemterkep.terkep[index])
                    {
                        case 0:
                            map.Add(('█', ConsoleColor.Blue));
                            break;
                        case 1:
                            map.Add(('█', ConsoleColor.Green));
                            break;
                        case 2:
                            map.Add(('█', ConsoleColor.Red));
                            break;
                        case 3:
                            map.Add(('█', ConsoleColor.Gray));
                            break;
                        case 4:
                            map.Add(('█', ConsoleColor.DarkGray));
                            break;
                    }
                }

                if ((index + 1) % lineWidth == 0)
                {
                    map.Add(('\n', ConsoleColor.White));
                }
            }
            return map;
        }
        public void Mozgas(ConsoleKey info, Jatekos jatekos, Palya nemterkep)
        {
            switch (info)
            {
                case ConsoleKey.W:
                    if (jatekos.Poz > 60)
                    {
                        jatekos.Poz -= 60;
                    }
                    else
                    {
                        break;
                    }
                    break;
                case ConsoleKey.D:
                    if ((jatekos.Poz + 1) % 60 != 0)
                    {
                        jatekos.Poz += 1;
                    }
                    else
                    {
                        break;
                    }
                    break;
                case ConsoleKey.S:
                    if (jatekos.Poz + 60 < nemterkep.terkep.Length)
                    {
                        jatekos.Poz += 60;
                    }
                    else
                    {
                        break;
                    }
                    break;
                case ConsoleKey.A:
                    if ((jatekos.Poz) % 60 != 0)
                    {
                        jatekos.Poz -= 1;
                    }
                    else
                    {
                        break;
                    }
                    break;
            }
        }
        public string Megerkezes(ConsoleKey info, Jatekos jatekos, Palya Nemterkep)
        {
            if ((jatekos.PozSzam == 2 || jatekos.PozSzam == 3))
            {
                switch (info)
                {

                    case ConsoleKey.S:
                        return "Semmit nem csináltál";
                    case ConsoleKey.V:
                        try
                        {
                            return Vasarlas(Nemterkep, jatekos);
                        }
                        catch (Exception ex)
                        {
                            return ex.Message;
                        }
                    case ConsoleKey.M:
                        return jatekos.Munka();
                    default:
                        throw new Exception("\nNem megy az opciók közüli kiválasztás? \n");
                }

            }
            return "";
        }
    }
}
