using System.Linq.Expressions;
using System.Threading.Tasks.Dataflow;

namespace VideoJatekSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jatekos Herny = new Jatekos() { Eletero = 100, Tamadas = 50, Penc = 10, Poz = 3, PozSzam = 1 };
            Ellenseg Makvratr = new Ellenseg() { Eletero = 400, Tamadas = 200, Fokozat = 5 };
            Ellenseg Reszeg_Paraszt_Bottal = new Ellenseg() { Eletero = 70, Tamadas = 30, Fokozat = 1 };
            Ellenseg Paraszt = new Ellenseg() { Eletero = 100, Tamadas = 40, Fokozat = 2 };
            Ellenseg Alap_Bandita = new Ellenseg() { Eletero = 150, Tamadas = 110, Fokozat = 3 };
            Ellenseg Magasan_Kepzett_Bandita = new Ellenseg() { Eletero = 190, Tamadas = 160, Fokozat = 4 };
            int markvratr_poz = 713;

            int linewidth = 60;
            int[] map = 
            {
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                

            };
            
            bool won = false;
            while (won == false) {
                Herny.PozSzam = map[Herny.Poz];
                int index = 0;
                
                foreach (int i in map) { 
                    if(Herny.Poz == index)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("█");
                    }
                    if(markvratr_poz == index)
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
                if (Herny.PozSzam ==2 || Herny.PozSzam == 3)
                {
                    switch(Telepulesimenu())
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                    }
                }
                Console.ForegroundColor= ConsoleColor.White;
                Console.WriteLine("");
                switch(Menu())
                {
                    case "w":
                        if (Herny.Poz > 60)
                        {
                            Herny.Poz -= 60;
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case "d":
                        if ((Herny.Poz +1) % 60 != 0)
                        {
                            Herny.Poz += 1;
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case "s":
                        if (Herny.Poz +  60 < map.Length)
                        {
                            Herny.Poz += 60;
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case "a":
                        if ((Herny.Poz) % 60 != 0)
                        {
                            Herny.Poz -= 1;
                        }
                        else
                        {
                            break;
                        }
                        break;
                }
                Console.Clear();
            }
        }

         static string Telepulesimenu()
        {
            Console.WriteLine("Akarsz-e valamit csinálni?");
            Console.WriteLine("\t1: Semmit");
            Console.WriteLine("\t2: Vásásrlás");
            Console.WriteLine("\t3: Munka");
            Console.Write("Mi a választásod? ");
            return Convert.ToString(Console.ReadLine())!; ;
        }

        static string Menu()
        {
            Console.WriteLine("Melyik irányba haladjunk tovább?");
            Console.WriteLine("\tw: fel");
            Console.WriteLine("\td: jobbra");
            Console.WriteLine("\ts: lefelé");
            Console.WriteLine("\ta: balra");
            Console.Write("Merre? ");
            return Convert.ToString(Console.ReadLine())!;
        }
    }
}
