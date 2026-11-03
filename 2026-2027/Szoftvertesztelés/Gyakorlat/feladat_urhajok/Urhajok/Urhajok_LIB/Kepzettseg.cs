using System;
using System.Collections.Generic;
using System.Text;

namespace Urhajok_LIB
{
    public class Kepzettseg
    {
        public string Nev { get; init; }
        public int Szint { get; init; }

        public Kepzettseg(string nev, int szint)
        {
            if (string.IsNullOrWhiteSpace(nev)) throw new ArgumentException("A képzettség nevét kötelező megadni!");

            Nev = nev;
            Szint = szint;
        }
    }
}
