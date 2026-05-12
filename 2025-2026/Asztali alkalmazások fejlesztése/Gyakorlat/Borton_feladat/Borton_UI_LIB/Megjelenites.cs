using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Borton_UI_LIB;

namespace Borton_UI_LIB
{
    public static class ConsoleListazo
    {
        public static void Lista<T>(string cim, IEnumerable<T> elemek)
        {
            Console.Clear();
            Menu.Fejlec(cim);

            if (!elemek.Any())
            {
                Console.WriteLine("Nincs megjeleníthető adat!");
            }
            else
            {
                foreach (var e in elemek)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("--------------------------------");
                }
            }

            Menu.Varakozas();
        }
    }
}
