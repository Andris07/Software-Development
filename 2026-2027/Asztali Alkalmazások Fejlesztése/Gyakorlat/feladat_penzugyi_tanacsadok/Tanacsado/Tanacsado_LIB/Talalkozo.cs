using System;
using System.Collections.Generic;
using System.Text;

namespace Tanacsado_LIB
{
    public class Talalkozo
    {
        // talalkozo_id;tanacsado_id;ugyfel_id;datum;idopont;idotartam
        public int ID { get; init; }
        public int TanacsadoID { get; init; }
        public int UgyfelID { get; init; }
        public DateOnly Datum { get; init; }
        public TimeSpan Idopont { get; init; }
        public int Idotartam { get; init; }

        public Talalkozo(string sor)
        {
            string[] adatok = sor.Split(";");

            ID = int.Parse(adatok[0]);
            TanacsadoID = int.Parse(adatok[1]);
            UgyfelID = int.Parse(adatok[2]);
            Datum = DateOnly.Parse(adatok[3]);
            Idopont = TimeSpan.Parse(adatok[4]);
            Idotartam = int.Parse(adatok[5]);
        }
    }
}
