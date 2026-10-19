using System;
using System.Collections.Generic;
using System.Text;

namespace StarTrek_LIB
{
    public class HajoSzerepek
    {
        // szerep_id;szerep_nev
        public int ID { get; init; }
        public string Nev { get; init; }

        public HajoSzerepek(string sor)
        {
            string[] adatok = sor.Split(";");

            ID = int.Parse(adatok[0]);
            Nev = adatok[1];
        }
    }
}
