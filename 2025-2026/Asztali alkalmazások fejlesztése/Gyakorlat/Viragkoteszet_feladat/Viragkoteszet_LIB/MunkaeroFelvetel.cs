using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public class MunkaeroFelvetel
    {
        Dolgozo munkaero { get; init; }

        public MunkaeroFelvetel(string fájlSor)
        {
            string[] adatok = fájlSor.Split(";");
            this.munkaero = new Dolgozo(int.Parse(adatok[0]), adatok[1]);
        }
    }
}
