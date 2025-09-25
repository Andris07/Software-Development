using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace forma1_LIB
{
    public class Forma1k
    {
        List<Forma1> forma1k = new List<Forma1>();

        public Forma1k(IEnumerable<string> fajlSorok)
        {
            foreach (string fajlSor in fajlSorok.Skip(1))
            {
                string[] sor = fajlSor.Split(';');
                DateOnly datum = DateOnly.Parse(sor[0]);
                string helyszin = sor[1];
                string nev = sor[2];
                string nem = sor[3];
                DateOnly? szuletesDatum = DateNullable(sor[4]);
                string nemzetiseg = sor[5];
                int? helyezes = ParseNullable(sor[6]);
                string? hiba = StringNullable(sor[7]);
                string? csapat = StringNullable(sor[8]);
                string tipus = sor[9];
                string motor = sor[10];

                string? StringNullable(string szoveg) => string.IsNullOrEmpty(szoveg) ? null : szoveg;
                DateOnly? DateNullable(string datum) => string.IsNullOrEmpty(datum) ? null : DateOnly.Parse(datum);
                int? ParseNullable(string szam) => string.IsNullOrEmpty(szam) ? null : int.Parse(szam);

                forma1k.Add(new Forma1(datum, helyszin, nev, nem, szuletesDatum, nemzetiseg, helyezes, hiba, csapat, tipus, motor));
            }
        }

        public IEnumerable<Forma1> versenyzokNevAlapjan(string nev) => forma1k.Where(x => x.Nev.Split(" ")[1] == nev).DistinctBy(x => x.Nev).OrderBy(x => x.SzuletesDatum);
        public IEnumerable<Forma1> futamGyoztesek() => forma1k.Where(x => x.Helyezes == 1).DistinctBy(x => x.Nev).OrderBy(x => x.Nev);
        public Forma1 elsoVerseny(string nev) => forma1k.Where(x => x.Nev == nev).OrderBy(x => x.Datum).First();
        public Dictionary<string, int> leggyakoribbHibakCsapatonkent(string csapat, int hibakSzama) => forma1k.Where(x => x.Tipus == csapat).Where(x => x.Hiba != null).GroupBy(x => x.Hiba).OrderByDescending(x => x.Count()).Take(hibakSzama).ToDictionary(x => x.Key, x => x.Count());
        public int csapatNelkulVersenyzok() => forma1k.Where(x => x.Csapat == null).DistinctBy(x => x.Nev).Count();
        public List<string> elsoRendezesUtaniHelyszinek(string orszag) => forma1k.OrderByDescending(x => x.Datum).DistinctBy(x => x.Helyszin).Where(x => x.Helyszin != orszag).Where(x => x.Datum > forma1k.OrderBy(x => x.Datum).DistinctBy(x => x.Helyszin).Where(x => x.Helyszin == orszag).First().Datum).Select(x => x.Helyszin).OrderBy(x => x).ToList();

        public void fajlBeiras(string fajl, string orszag)
        {
            StreamWriter file = new StreamWriter(fajl);

            foreach (var ev in forma1k.Where(x => x.Helyszin == orszag && x.Helyezes != null).OrderBy(x => x.Datum).ThenBy(x => x.Helyezes).GroupBy(x => x.Datum).Take(6))
            {
                file.WriteLine($"{ev.Key.Year}");

                foreach (var evStatisztika in ev)
                {
                    file.WriteLine($"\t{evStatisztika.Helyezes}. {evStatisztika.Nev} ({evStatisztika.Csapat} {evStatisztika.Tipus})");
                }
            }
            file.Close();
        }
    }
}
