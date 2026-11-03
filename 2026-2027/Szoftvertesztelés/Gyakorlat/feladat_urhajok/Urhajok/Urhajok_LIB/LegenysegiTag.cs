using System;
using System.Collections.Generic;
using System.Text;

namespace Urhajok_LIB
{
    public class LegenysegiTag
    {
        public string Nev { get; init; }
        public string Nemzetiseg { get; init; }
        public DateOnly SzuletesiDatum { get; init; }
        public string Nem { get; init; }
        public List<Kepzettseg> Kepzettsegek { get; init; }

        public LegenysegiTag(string nev, string nemzetiseg, DateOnly szuletesiDatum, string nem, IEnumerable<Kepzettseg> kepzettsegek)
        {
            Nev = nev;
            Nemzetiseg = nemzetiseg;
            SzuletesiDatum = szuletesiDatum;
            Nem = nem;
            Kepzettsegek = kepzettsegek.ToList();
        }

        public int KepzettsegSzint(string kepzettsegNev) => Kepzettsegek.Where(x => x.Nev == kepzettsegNev).Sum(x => x.Szint);
    }
}
