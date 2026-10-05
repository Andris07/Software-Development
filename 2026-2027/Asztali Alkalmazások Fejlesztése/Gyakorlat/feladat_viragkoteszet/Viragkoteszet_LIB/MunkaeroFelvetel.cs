using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public class MunkaeroFelvetel
    {
        public Dolgozo Munkaero { get; }

        // ID;Nev;Beosztas;Alapanyagok (a Beosztas "v" = virágkötő, "gy" = gyakornok,
        // gyakornok esetén az általa már ismert termékek azonosítói következnek)
        public MunkaeroFelvetel(string fájlSor)
        {
            string[] adatok = fájlSor.Split(";");
            int dolgozoID = int.Parse(adatok[0]);
            string dolgozoNev = adatok[1];
            string beosztas = adatok[2];

            if (beosztas == "v")
            {
                this.Munkaero = new Viragkoto(dolgozoID, dolgozoNev);
            }
            else
            {
                IEnumerable<int> ismertTermekek = adatok.Skip(3).Select(int.Parse);
                this.Munkaero = new Gyakornok(dolgozoID, dolgozoNev, ismertTermekek);
            }
        }
    }
}
