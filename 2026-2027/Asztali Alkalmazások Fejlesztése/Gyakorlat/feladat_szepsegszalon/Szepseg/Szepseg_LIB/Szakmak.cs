using System;
using System.Collections.Generic;
using System.Text;

namespace Szepseg_LIB
{
    public class Szakmak
    {
        // szakmaId;nev
        public int ID { get; init; }
        public string Nev { get; init; }

        public Szakmak(string sor)
        {
            string[] adatok = sor.Split(";");

            ID = int.Parse(adatok[0]);
            Nev = adatok[1];
        }
    }
}
