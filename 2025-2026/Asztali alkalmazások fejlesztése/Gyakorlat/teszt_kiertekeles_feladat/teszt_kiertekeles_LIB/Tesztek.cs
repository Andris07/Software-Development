using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teszt_kiertekeles_LIB
{
    public class Tesztek
    {
        List<Teszt>? tesztek = new List<Teszt>();

        public Tesztek(IEnumerable<string> fajlSorok)
        {
            foreach (string fajlSor in fajlSorok.Skip(1))
            {
                string[] sor = fajlSor.Split(';');
                string? nev = StringNullable(sor[0]);
                int? elsoFeladat = ParseNullable(sor[1]);
                int? masodikFeladat = ParseNullable(sor[2]);
                int? harmadikFeladat = ParseNullable(sor[3]);
                int? negyedikFeladat = ParseNullable(sor[4]);
                int? otodikFeladat = ParseNullable(sor[5]);

                string? StringNullable(string szoveg) => string.IsNullOrEmpty(szoveg) ? null : szoveg;  // Lehetséges NULL string szűrése, majd ez alapján értékadás (vagy null vagy maga a szöveg)
                int? ParseNullable(string szam) => string.IsNullOrEmpty(szam) ? null : int.Parse(szam); // Lehetséges NULL int szűrése, majd ez alapján értékadás (vagy null vagy maga a szám)

                tesztek.Add(new Teszt(nev, elsoFeladat, masodikFeladat, harmadikFeladat, negyedikFeladat, otodikFeladat));
            }
        }

        // 1. feladat
        public int csoportLetszam() => tesztek.Count();
        public bool ures() => csoportLetszam() == 0;
        public int tesztIrokLetszam() => csoportLetszam() - tesztek.Count(x => x.Nev == null);

        // 2. feladat
        public bool irtTesztet(string? nev) => tesztek.Any(x => x.Nev == nev && !string.IsNullOrEmpty(nev));
        public IEnumerable<Teszt> tesztIro(string? nev) => tesztek.Where(x => x.Nev == nev);

        // 3. feladat
        public (int megoldok, double atlag, int kihagyok) feladatStatisztika(int feladatIndex)
        {
            var megoldok = tesztek.Where(x => x.Nev != null && x.FeladatPontszamLekeres(feladatIndex) != null).ToList();
            int kihagyok = tesztek.Count(x => x.Nev != null && x.FeladatPontszamLekeres(feladatIndex) == null);
            double atlag = megoldok.Any() ? megoldok.Average(x => x.FeladatPontszamLekeres(feladatIndex).Value) : 0;
            return (megoldok.Count(), Math.Round(atlag, 2), kihagyok);
        }

        // 4. feladat
        public void mentesSzazalekCsv(int csoportSzam)
        {
            string fajlNev = $"szazalek{csoportSzam}.csv";
            StreamWriter fajlBeiras = new StreamWriter(fajlNev, false, Encoding.UTF8);
            fajlBeiras.WriteLine("sorszám;név;százalék;eredmény");

            for (int i = 0; i < tesztek.Count(); i++)
            {
                var tanulo = tesztek[i];

                if (tanulo.Nev == null)
                {
                    fajlBeiras.WriteLine($"{i + 1}");
                }
                else
                {
                    fajlBeiras.WriteLine($"{i + 1};{tanulo.Nev};{Math.Round(tanulo.szazalek)}%;{tanulo.eredmeny}");
                }
            }
            fajlBeiras.Close();
        }
    }
}