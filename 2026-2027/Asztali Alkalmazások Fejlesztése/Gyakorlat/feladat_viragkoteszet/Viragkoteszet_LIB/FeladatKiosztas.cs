using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public class FeladatKiosztas
    {
        // DolgozoID;TermekID
        public static void Kioszt(string fájlSor, Dolgozok dolgozok, Termekek termekek)
        {
            string[] adatok = fájlSor.Split(";");
            int dolgozoID = int.Parse(adatok[0]);
            int termekID = int.Parse(adatok[1]);

            Dolgozo dolgozo = dolgozok[dolgozoID] ?? throw new HibasFeladatException();
            Termek termek = termekek[termekID] ?? throw new HibasFeladatException();

            dolgozo.UjFeladatHozzaadasa(termek);
        }
    }
}
