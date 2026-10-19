using System;
using System.Collections.Generic;
using System.Text;

namespace Szepseg_LIB
{
    public class Kezelesek
    {
        // kezelesId;alkalmazottId;vendegID;datum;idopont;ar
        public int ID { get; init; }
        public int AlkalmazottID { get; init; }
        public int VendegID { get; init; }
        public DateOnly Datum { get; init; }
        public TimeSpan Idopont { get; init; }
        public int Ar { get; init; }

        public Kezelesek(string sor)
        {
            string[] adatok = sor.Split(";");

            ID = int.Parse(adatok[0]);
            AlkalmazottID = int.Parse(adatok[1]);
            VendegID = int.Parse(adatok[2]);
            Datum = DateOnly.Parse(adatok[3]);
            Idopont = TimeSpan.Parse(adatok[4]);
            Ar = int.Parse(adatok[5]);
        }
    }
}
