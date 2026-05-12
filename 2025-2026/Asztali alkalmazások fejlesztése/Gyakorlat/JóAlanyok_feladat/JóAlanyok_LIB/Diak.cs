using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JóAlanyok_LIB
{
    public sealed class Diak : Szemely, IVizsgalat
    {
        public int PuskakSzama { get; init; }

        public Diak(string nev, DateOnly szulDatum, int puskakSzama) : base(nev, szulDatum)
        {
            this.PuskakSzama = puskakSzama;
        }

        public bool JoAlanyE() => PuskakSzama == 0 ? true : false;

        public override string ToString()
        {
            return $"{base.ToString()} {(JoAlanyE() ? "Jó" : "Rossz")} diák";
        }
    }
}
