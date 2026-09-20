using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForditoIrodaLIB
{
    public class Nyelv
    {
        public int NyelvID { get; init; }
        public string Nyelvnev { get; init; }

        public Nyelv(string fajlSor)
        {
            string[] adatok = fajlSor.Split(";");
            this.NyelvID = int.Parse(adatok[0]);
            this.Nyelvnev = adatok[1];
        }
    }
}
