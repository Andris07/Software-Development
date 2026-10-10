using System;
using System.Collections.Generic;
using Hanoi_LIB;

namespace Hanoi_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hány koronggal játszol? (1-8): ");
            int n = int.TryParse(Console.ReadLine(), out int parsed) ? Math.Clamp(parsed, 1, 8) : 3;

            var hanoi = new Hanoi(n);
            int mozgások = 0;
            hanoi.Megjelenítés();

            Console.WriteLine("Irányítás: adj meg két rúdát (A, B vagy C) az áthelyezéshez.");
            Console.WriteLine("Példa: 'A B' → egy korongot A-ról B-re.");
            Console.WriteLine("Írd be 'újra', ha újra kezded.");
            Console.WriteLine("Írd be 'kilépés', ha abba akarod hagyni.\n");

            while (true)
            {
                Console.Write("Mozgás: ");
                string bemenet = Console.ReadLine()?.Trim() ?? "";

                if (bemenet.ToLower() == "újra")
                {
                    hanoi = new Hanoi(n);
                    mozgások = 0;
                    hanoi.Megjelenítés();
                    continue;
                }
                else if (bemenet.ToLower() == "kilépés") return;

                var rúdok = bemenet.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (rúdok.Length != 2)
                {
                    Console.WriteLine("Két rúdát adj meg, pl. 'A B'\n");
                    continue;
                }

                Stack<int> innen = RúdKiválasztás(hanoi, rúdok[0]);
                Stack<int> ide = RúdKiválasztás(hanoi, rúdok[1]);

                if (innen == null || ide == null)
                {
                    Console.WriteLine("Érvénytelen rúd! Használd: A, B vagy C.\n");
                    continue;
                }

                try
                {
                    Hanoi.KorongÁttevés(innen, ide, ref mozgások);
                    hanoi.Megjelenítés();

                    if (Hanoi.JátékVége(hanoi.A, hanoi.B, hanoi.C, hanoi.Korongok))
                    {
                        Console.WriteLine($"Gratulálok! {mozgások} mozgás.");
                        break;
                    }
                }
                catch (ÜresRúdException e)
                {
                    Console.WriteLine($"{e.Message}\n");
                }
                catch (NemTehetőÁtException e)
                {
                    Console.WriteLine($"{e.Message}\n");
                }
            }

            Console.WriteLine("\nKöszönöm a játékot!");
        }

        static Stack<int> RúdKiválasztás(Hanoi h, string név)
        {
            return név.ToUpper() switch
            {
                "A" => h.A,
                "B" => h.B,
                "C" => h.C,
            };
        }
    }
}