using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borton_UI_LIB
{
    public static class Bevitel
    {
        public static string Szoveg(string prompt)
        {
            Console.Write(prompt + ": ");
            return Console.ReadLine() ?? "";
        }

        public static int Szam(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + ": ");
                if (int.TryParse(Console.ReadLine(), out int szam))
                    return szam;

                Menu.Hiba("Számot adj meg!");
            }
        }
    }
}
