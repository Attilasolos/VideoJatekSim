using System.Linq.Expressions;
using System.Threading.Tasks.Dataflow;

namespace VideoJatekSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jatekos Herny = new Jatekos() { Eletero = 100, Tamadas = 50, Penc = 10, Poz = 3, PozSzam = 1, Karizma = 0, Vege = false, Gyozott = false };
            int markvratr_poz = 713;
            Palya Telepules = new Palya();
            int lepes_szam = 0;
            int linewidth = 60;
            Random rand = new Random();
            Console.Write("Ez a projekt egy egyszerű rpg játékot szimulál ahol a kék a vizet jelzi, a zöld a mezőt \na vörös a falukat a szürke a várost és a sötétszürke a várat\n\nÉrted a játék írányítását");
            Console.ReadKey();
            Console.Write("IV Károly király halála után fia II Makvratr király egy erős és gazdag királyságot örökölt,de a vasököllel való \nuralkodása és a rossz gazdaságpolitikája rossz hatással volt az életminőségre,ezért egy nagyon hatásos \nvérnyomáscsökkentő éjszaka után elhatározod hogy ennek véget kell vetni és felébredsz egy mezőn\n\nKezdődhet a játék");
            Console.ReadKey();
            Console.Clear();
            while (Herny.Vege == false)
            {
                Herny.PozSzam = Telepules.terkep[Herny.Poz];
                var map = Telepules.GenerateMap(Herny.Poz, markvratr_poz, linewidth);
                foreach (var (character, color) in map)
                {
                    Console.ForegroundColor = color;
                    Console.Write(character);
                }
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
                Console.Write("\tPénz: " + Herny.Penc + " Gr\n\n");

                Console.ForegroundColor = ConsoleColor.White;
                Herny.Talalkozas();
                Console.Write( Herny.Telepulesimenuszoveg());
                Herny.Megerkezes(Console.ReadKey().Key!);
                Console.Write(Herny.MenuSzoveg());
                Herny.Mozgas(Console.ReadKey().Key!);
                Console.Clear();
            if (Herny.Poz == markvratr_poz)
                Herny.Vegso_csata();
                lepes_szam++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            if(Herny.Gyozott == true)
            {
                Console.WriteLine("A hősi küldetésed sikerrel zárult, a király elhalálozása a gravticáció\n által nem lett rajtad felelősségre vonva, az hogy ki lesz az \núj király az már más gondja");
            }
            else
            {
                Console.WriteLine("A hősi küldetésed rövid és elég szomorú véget ért,na ne csüggedj\nhiszen így esélyt adtál arra hogy más vigye el a hírnevet.\n");
            }
            Console.ReadLine();
        }
    }
}