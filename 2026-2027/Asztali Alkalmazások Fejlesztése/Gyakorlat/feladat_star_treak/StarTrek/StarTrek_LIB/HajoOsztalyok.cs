using System;
using System.Collections.Generic;
using System.Text;

namespace StarTrek_LIB
{
    public class HajoOsztalyok
    {
        // osztaly_id;osztaly_nev;szerep_id
        public int ID { get; init; }
        public string Nev { get; init; }
        public int SzerepID { get; init; }

        public HajoOsztalyok(string sor)
        {
            string[] adatok = sor.Split(";");

            ID = int.Parse(adatok[0]);
            Nev = adatok[1];
            SzerepID = int.Parse(adatok[2]);
        }
    }
}
