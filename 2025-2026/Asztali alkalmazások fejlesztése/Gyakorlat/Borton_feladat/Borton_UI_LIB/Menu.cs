using Borton_UI_LIB;

namespace Borton_UI_LIB
{
    public static class Menu
    {
        public static int ValasztoMenu(string cim, string[] opciok)
        {
            while (true)
            {
                Console.Clear();
                Fejlec(cim);

                for (int i = 0; i < opciok.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {opciok[i]}");
                }

                Console.Write("\nVálasztás: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int valasztas))
                {
                    if (valasztas >= 1 && valasztas <= opciok.Length)
                        return valasztas;
                }

                Hiba("Érvénytelen választás!");
            }
        }

        public static void Fejlec(string szoveg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======================================");
            Console.WriteLine(szoveg.ToUpper());
            Console.WriteLine("======================================\n");
            Console.ResetColor();
        }

        public static void Hiba(string uzenet)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nHIBA: " + uzenet);
            Console.ResetColor();
            Varakozas();
        }

        public static void Info(string uzenet)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + uzenet);
            Console.ResetColor();
            Varakozas();
        }

        public static void Varakozas()
        {
            Console.WriteLine("\nNyomj ENTER-t a folytatáshoz...");
            Console.ReadLine();
        }
    }
}