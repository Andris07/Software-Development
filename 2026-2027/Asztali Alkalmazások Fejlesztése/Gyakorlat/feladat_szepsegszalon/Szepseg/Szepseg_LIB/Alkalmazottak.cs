using System;
using System.Collections.Generic;
using System.Text;

namespace Szepseg_LIB
{
    public class Alkalmazottak
    {
        // alkalmazottId;nev;szakmaId;telefon
        public int ID { get; init; }
        public string Nev { get; init; }
        public int SzakmaID { get; init; }
        public string Telefon { get; init; }

        public Alkalmazottak(string sor)
        {
            string[] adatok = sor.Split(";");

            ID = int.Parse(adatok[0]);
            Nev = adatok[1];
            SzakmaID = int.Parse(adatok[2]);
            Telefon = adatok[3];
        }
    }
}
