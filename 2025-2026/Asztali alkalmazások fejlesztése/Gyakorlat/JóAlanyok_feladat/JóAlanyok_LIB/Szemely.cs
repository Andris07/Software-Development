using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JóAlanyok_LIB
{
    public class Szemely
    {
        public string Nev { get; init; }
        private DateOnly SzuletesiDatum { get; init; }
        public int Kor => DateTime.Now.Year - SzuletesiDatum.Year;

        public Szemely(string nev, DateOnly szuletesiDatum)
        {
            this.Nev = nev;
            this.SzuletesiDatum = szuletesiDatum;

            if (Kor < 14)
            {
                throw new HibasEletkorException();
            }
        }

        public override string ToString()
        {
            return $"{Nev} ({Kor})";
        }
    }
}
