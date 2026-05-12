using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JóAlanyok_LIB
{
    public class Tanar : Szemely, IVizsgalat
    {
        public double AtlagEvVegiJegyek { get; init; }

        public Tanar(string nev, DateOnly szuletesiDatum, double átlagÉvVégiJegyek) : base(nev, szuletesiDatum)
        {
            this.AtlagEvVegiJegyek = átlagÉvVégiJegyek;
        }

        public bool JoAlanyE() => Kor < 30 && AtlagEvVegiJegyek >= 3.5;

        public override string ToString()
        {
            return $"{base.ToString()} {(JoAlanyE() ? "Jó" : "Rossz")} tanár";
        }
    }
}
