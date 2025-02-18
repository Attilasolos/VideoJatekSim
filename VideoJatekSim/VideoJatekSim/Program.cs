using System.Linq.Expressions;
using System.Threading.Tasks.Dataflow;

namespace VideoJatekSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jatekos Herny = new Jatekos() { Eletero = 100, Tamadas = 50, Penc = 10, Poz = 3, PozSzam = 1, Karizma = 0, Vege = false, Gyozott = false };
            Ellenseg Makvratr = new Ellenseg() { Eletero = 400, Tamadas = 200, Fokozat = 5 };
            Ellenseg Reszeg_Paraszt_Bottal = new Ellenseg() { Eletero = 70, Tamadas = 30, Fokozat = 1 };
            Ellenseg Paraszt = new Ellenseg() { Eletero = 100, Tamadas = 40, Fokozat = 2 };
            Ellenseg Alap_Bandita = new Ellenseg() { Eletero = 150, Tamadas = 110, Fokozat = 3 };
            Ellenseg Magasan_Kepzett_Bandita = new Ellenseg() { Eletero = 190, Tamadas = 160, Fokozat = 4 };
            int markvratr_poz = 713;
            Palya Telepules = new Palya();
            int lepes_szam = 0;
            int linewidth = 60;
            Random rand = new Random();
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
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Érted a játék írányítását");
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Kezdődhet a játék");
            Console.ReadKey();
            Console.Clear();

            while (Herny.Vege == false)
            {
                Herny.PozSzam = terkep[Herny.Poz];
                int index = 0;

                foreach (int i in terkep)
                {
                    if (Herny.Poz == index)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("█");
                    }
                    else if (markvratr_poz == index)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("█");
                    }
                    else
                    {
                        switch (i)
                        {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("█");
                                break;
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("█");
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("█");
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("█");
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("█");
                                break;
                        }
                    }
                    index++;
                    if (index % linewidth == 0)
                    {
                        Console.WriteLine("");
                    }

                }
                Console.WriteLine("");
                if (Herny.Eletero > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (Herny.Eletero > 80)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else if (Herny.Eletero > 60)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (Herny.Eletero > 30)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (Herny.Eletero > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                Console.Write("Életerő: " + Herny.Eletero);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tTámadás: " + Herny.Tamadas);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\tPénz: " + Herny.Penc + " Gr");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.WriteLine("");
                if (lepes_szam > 25 && Herny.PozSzam == 1)
                {

                    int szerencse = rand.Next(1, 101);
                    if (szerencse <= 5)
                    {
                        Console.WriteLine("Ellenség támad rád");
                        int ellenseg_szint = rand.Next(1, 15);
                        if (ellenseg_szint <= 5)
                        {
                            Herny.Csata_feldolgozas(Reszeg_Paraszt_Bottal);
                        }
                        else if (ellenseg_szint <= 9)
                        {

                            Herny.Csata_feldolgozas(Paraszt);
                        }
                        else if (ellenseg_szint <= 12)
                        {

                            Herny.Csata_feldolgozas(Alap_Bandita);
                        }
                        else
                        {
                            Herny.Csata_feldolgozas(Magasan_Kepzett_Bandita);
                        }
                    }
                }

                if ((Herny.PozSzam == 2 || Herny.PozSzam == 3))
                {
                    switch (Telepulesimenu())
                    {
                        case ConsoleKey.S:
                            break;
                        case ConsoleKey.V:
                            Console.WriteLine(Herny.Vasarlas(Telepules));
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine(Herny.Munka());

                            break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;

                switch (Menu())
                {
                    case ConsoleKey.W:
                        if (Herny.Poz > 60 || terkep[Herny.Poz - 60] != 4 && Herny.Karizma > 6)
                        {
                            Herny.Poz -= 60;
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case ConsoleKey.D:
                        if ((Herny.Poz + 1) % 60 != 0 || terkep[Herny.Poz + 1] != 4 && Herny.Karizma > 6)
                        {
                            Herny.Poz += 1;
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case ConsoleKey.S:
                        if (Herny.Poz + 60 < terkep.Length || terkep[Herny.Poz + 60] != 4 && Herny.Karizma > 6)
                        {
                            Herny.Poz += 60;
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case ConsoleKey.A:
                        if ((Herny.Poz) % 60 != 0 || terkep[Herny.Poz - 1] != 4 && Herny.Karizma > 6)
                        {
                            Herny.Poz -= 1;
                        }
                        else
                        {
                            break;
                        }
                        break;
                }
                if (Herny.Poz == markvratr_poz)
                {
                    if (Herny.Csata_feldolgozas(Makvratr) == "\nNyertél\n")
                    {
                        Herny.Gyozott = true;
                        Herny.Vege = true;
                    }
                    if (Herny.PozSzam == 1)
                    {
                        lepes_szam++;
                    }
                }
                    Console.Clear();
            }
            if(Herny.Gyozott == true)
            {
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
            }
            Console.ReadLine();
        }

            static ConsoleKey Telepulesimenu()
            {
                Console.WriteLine("Akarsz-e valamit csinálni?");
                Console.WriteLine("\tS: Semmit");
                Console.WriteLine("\tV: Vásásrlás");
                Console.WriteLine("\tM: Munka");
                Console.Write("Mi a választásod? ");
                return Console.ReadKey().Key!;
            }

            static ConsoleKey Menu()
            {
                Console.WriteLine("Melyik irányba haladjunk tovább?");
                Console.WriteLine("\tW: fel");
                Console.WriteLine("\tD: jobbra");
                Console.WriteLine("\tS: lefelé");
                Console.WriteLine("\tA: balra");
                Console.Write("Merre? ");
                return Console.ReadKey().Key!;
            }

        
    }
}