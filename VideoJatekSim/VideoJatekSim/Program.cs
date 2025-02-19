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
            Iras iro = new Iras();
            Palya Telepules = new Palya();
            int lepes_szam = 0;
            int linewidth = 60;
            Console.Write("Ez a projekt egy egyszerű open world játékot szimulál ahol a kék a vizet jelzi, a zöld a mezőt \na vörös a falukat a szürke a várost és a sötétszürke a várat\n\nÉrted a játék írányítását");
            Console.ReadKey();
            Console.Write("IV Károly király halála után fia II Makvratr király egy erős és gazdag királyságot örökölt,de a vasököllel való \nuralkodása és a rossz gazdaságpolitikája rossz hatással volt az életminőségre,ezért egy nagyon hatásos \nvérnyomáscsökkentő éjszaka után elhatározod hogy ennek véget kell vetni és felébredsz egy mezőn\n\nKezdődhet a játék");
            Console.ReadKey();
            Console.Clear();
            while (Herny.Vege == false)
            {
                Herny.PozSzam = Telepules.terkep[Herny.Poz];
                var map = iro.Terkep_Letrehozas(Herny.Poz, markvratr_poz, linewidth,Telepules);
                foreach (var (character, color) in map)
                {
                    Console.ForegroundColor = color;
                    Console.Write(character);
                }
                Console.ForegroundColor = iro.Jatekos_Eletero_szin(Herny);
                Console.Write("\nÉleterő: " + Herny.Eletero);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tTámadás: " + Herny.Tamadas);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\tPénz: " + Herny.Penc + " Gr\n\n");

                Console.ForegroundColor = ConsoleColor.White;
                
                
                Console.Write( Herny.Telepulesimenuszoveg());
                if (Herny.PozSzam == 2 || Herny.PozSzam == 3)
                    try
                    {
                        iro.Megerkezes(Console.ReadKey().Key!, Herny, Telepules);
                        
                    }
                    catch(Exception ex) 
                    {
                        Console.WriteLine(ex.Message);
                    }
                Console.WriteLine(Herny.Talalkozas());
                Console.Write(Herny.MenuSzoveg());
                try
                {
                    iro.Mozgas(Console.ReadKey().Key!, Herny, Telepules);
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
                Console.Clear();

                if (Herny.Poz == markvratr_poz)
                    Herny.Vegso_csata();
                Herny.LepesSzam++;
                
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            if(Herny.Gyozott == true)
            {
                Console.WriteLine("A hősi küldetésed sikerrel zárult, a király elhalálozása a gravitáció\náltal nem lett rajtad felelősségre vonva, az hogy ki lesz az \núj király az már más gondja");
            }
            else
            {
                Console.WriteLine("A hősi küldetésed rövid és elég szomorú véget ért, na ne csüggedj\nhiszen így esélyt adtál arra hogy más vigye el a hírnevet.\n");
            }
            Console.ReadLine();
        }
    }
}