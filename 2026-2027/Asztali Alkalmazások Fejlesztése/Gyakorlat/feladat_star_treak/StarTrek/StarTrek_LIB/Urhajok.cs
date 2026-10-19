using System;
using System.Collections.Generic;
using System.Text;

namespace StarTrek_LIB
{
    public class Urhajok
    {
        // urhajo_id;azonosito;urhajo_nev;osztaly_id;faj_id
        public int ID { get; init; }
        public string Azonosito { get; init; }
        public string Nev { get; init; }
        public int OsztalyID { get; init; }
        public int FajID { get; init; }

        public Urhajok(string sor)
        {
            string[] adatok = sor.Split(";");

            ID = int.Parse(adatok[0]);
            Azonosito = adatok[1];
            Nev = adatok[2];
            OsztalyID = int.Parse(adatok[3]);
            FajID = int.Parse(adatok[4]);
        }
    }
}
