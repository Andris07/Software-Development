using System;
using System.Collections.Generic;
using System.Text;

namespace Szepseg_LIB
{
    public class DataStore
    {
        readonly List<Vendegek> vendegek;
        readonly List<Kezelesek> kezelesek;
        readonly List<Alkalmazottak> alkalmazottak;
        readonly List<Szakmak> szakmak;

        public IEnumerable<Vendegek> Vendegek => vendegek;
        public IEnumerable<Kezelesek> Kezelesek => kezelesek;
        public IEnumerable<Alkalmazottak> Alkalmazottak => alkalmazottak;
        public IEnumerable<Szakmak> Szakmak => szakmak;

        public DataStore()
        {
            vendegek = File.ReadAllLines("Input\\vendegek.csv").Skip(1)
                .Select(x => new Vendegek(x)).ToList();

            kezelesek = File.ReadAllLines("Input\\kezelesek.csv").Skip(1)
                .Select(x => new Kezelesek(x)).ToList();

            alkalmazottak = File.ReadAllLines("Input\\alkalmazottak.csv").Skip(1)
                .Select(x => new Alkalmazottak(x)).ToList();

            szakmak = File.ReadAllLines("Input\\szakmak.csv").Skip(1)
                .Select(x => new Szakmak(x)).ToList();
        }

        public static DataStore? Instance { get; private set; }

        public static void InitCSV()
        {
            if (Instance is not null) throw new InvalidOperationException("Inicializáltál már!");
            Instance = new DataStore();
        }

        public Alkalmazottak AlkalmazottNevAlapjan(string nev) => Alkalmazottak.FirstOrDefault(x => x.Nev == nev)!;

        public int BevetelAlkalmazottAlapjan(Alkalmazottak alkalmazott) => Kezelesek.Where(x => x.AlkalmazottID == alkalmazott.ID).Sum(x => x.Ar);

        public int KezelesekSzamaIdopontSzerint(int ora) => Kezelesek.Count(x => x.Idopont.Hours < ora);

        public Vendegek VendegNevAlapjan(string nev) => Vendegek.FirstOrDefault(x => x.Nev == nev)!;

        public IEnumerable<(Alkalmazottak Alkalmazott, int Kereset)> LegtobbBevetellelRendelkezoAlkalmazott()
        {
            return
                kezelesek
                .GroupBy(x => x.AlkalmazottID)
                .Select(x => (
                    Alkalmazott: Alkalmazottak.First(y => y.ID == x.Key),
                    Kereset: BevetelAlkalmazottAlapjan(Alkalmazottak.FirstOrDefault(y => y.ID == x.Key)!)
                ))
                .OrderByDescending(x => x.Kereset)
                .ThenBy(x => x.Alkalmazott.Nev)
                .Take(3);
        }
    }
}
