using System;
using System.Collections.Generic;
using System.Text;

namespace Urhajok_LIB
{
    public class UrhajoTipus
    {
        public string Nev { get; init; }
        public string Leiras { get; init; }
        public List<Kepzettseg> ElvartKepzettsegek { get; init; }

        public UrhajoTipus(string nev, string leiras, IEnumerable<Kepzettseg>? elvartKepzettsegek)
        {
            Nev = nev;
            Leiras = leiras;
            ElvartKepzettsegek = elvartKepzettsegek?.ToList() ?? new List<Kepzettseg>();
        }
    }
}
