using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForditoIrodaLIB
{
    public class Megrendeles
    {
        public int MegrendelesID { get; init; }
        public int ForditoID { get; init; }
        public int MegrendeloID { get; init; }
        public DateTime Datum { get; init; }
        public int Oldalszam { get; init; }

        public Megrendeles(string fajlSor)
        {
            string[] adatok = fajlSor.Split(";");
            this.MegrendelesID = int.Parse(adatok[0]);
            this.ForditoID = int.Parse(adatok[1]);
            this.MegrendeloID = int.Parse(adatok[2]);
            this.Datum = DateTime.Parse(adatok[3]);
            this.Oldalszam = int.Parse(adatok[4]);
        }
    }
}
