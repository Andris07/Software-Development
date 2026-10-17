using System;
using System.Collections.Generic;
using System.Text;

namespace Tanacsado_LIB
{
    public class Tanacsado
    {
        // tanacsado_id;nev;szakterulet_id;oradij;telefon;email
        public int ID { get; init; }
        public string Nev { get; init; }
        public int SzakteruletID { get; init; }
        public int Oradij { get; init; }
        public string Telefon { get; init; }
        public string Email { get; init; }

        public Tanacsado(string sor)
        {
            string[] adatok = sor.Split(";");

            ID = int.Parse(adatok[0]);
            Nev = adatok[1];
            SzakteruletID = int.Parse(adatok[2]);
            Oradij = int.Parse(adatok[3]);
            Telefon = adatok[4];
            Email = adatok[5];
        }
    }
}
