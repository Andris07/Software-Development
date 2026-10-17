using System;
using System.Collections.Generic;
using System.Text;

namespace Tanacsado_LIB
{
    public class Szakterulet
    {
        // szakterulet_id;megnevezes
        public int ID { get; init; }
        public string Megnevezes { get; init; }

        public Szakterulet(string sor)
        {
            string[] adatok = sor.Split(";");

            ID = int.Parse(adatok[0]);
            Megnevezes = adatok[1];
        }
    }
}
