﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoJatekSim
{
    internal class Palya
    {
       public List<Targyak> falusi_piac { get; set; }

        public List<Targyak> varosi_piac { get; set; }
        public int[] terkep = new int[1260] {
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
        public Palya()
        {

            falusi_piac = new List<Targyak>
            {
                new Targyak("Alma", 2, 0, 0, 0, 3),
                new Targyak("Kenyér", 4, 0, 0, 0, 8),
                new Targyak("Fából készült buzogány", 0, 0, 110, 1, 15),
                new Targyak("Vasalt kesztyű", 0, 50, 0, 1, 20),
                new Targyak("Egyszerű láncing", 0, 100, 0, 3, 35)
            };

            varosi_piac = new List<Targyak>
            {
                new Targyak( "Sült hús", 10, 0, 0, 0, 25),
                new Targyak("Gyógyító ital", 30, 0, 0, 0, 40),
                new Targyak("Bárdkard", 0, 0, 210, 3, 200),
                new Targyak("Lovagi sisak", 0, 15, 0, 2, 50),
                new Targyak("Teljes lovagi páncél", 0, 310, 0, 6, 300)
            };
        }

        public void PiacMegjelenit(int pozSzam)
        {
            if (pozSzam == 2)
            {
                Console.WriteLine("");
                foreach (var aru in falusi_piac)
                {
                    Console.WriteLine($"{aru.Nev} - Ár: {aru.Ar} pénz, Védelem: {aru.Vedelem}, Sebzés: {aru.Sebzes}, Karizma: {aru.Karizmatikum}");
                    Console.WriteLine("");
                }
            }
            else if (pozSzam == 3)
            {
                Console.WriteLine("");
                foreach (var aru in varosi_piac)
                {
                    Console.WriteLine($"{aru.Nev} - Ár: {aru.Ar} pénz, Védelem: {aru.Vedelem}, Sebzés: {aru.Sebzes}, Karizma: {aru.Karizmatikum}");
                    Console.WriteLine("");               
                }
            }
        }

        public List<(char, ConsoleColor)> GenerateMap(int playerPos, int enemyPos, int lineWidth)
        {
            var map = new List<(char, ConsoleColor)>();
            for (int index = 0; index < terkep.Length; index++)
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
                    switch (terkep[index])
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
    }
}
