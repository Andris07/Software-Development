using System;
using System.Collections.Generic;
using System.Text;

namespace Urhajok_LIB
{
    public class UrhajoOsztaly
    {
        public string Nev { get; init; }

        public UrhajoOsztaly(string nev)
        {
            if (string.IsNullOrWhiteSpace(nev)) throw new ArgumentException("Az űrhajó osztály nevét kötelező megadni!");

            Nev = nev;
        }
    }
}
