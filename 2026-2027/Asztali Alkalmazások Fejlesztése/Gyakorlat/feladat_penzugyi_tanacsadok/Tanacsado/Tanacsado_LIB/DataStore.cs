using System;
using System.Collections.Generic;
using System.Text;

namespace Tanacsado_LIB
{
    public class DataStore
    {
        readonly List<Ugyfel> ugyfelek;
        readonly List<Talalkozo> talalkozok;
        readonly List<Tanacsado> tanacsadok;
        readonly List<Szakterulet> szakteruletek;

        public IEnumerable<Ugyfel> Ugyfelek => ugyfelek;
        public IEnumerable<Talalkozo> Talalkozok => talalkozok;
        public IEnumerable<Tanacsado> Tanacsadok => tanacsadok;
        public IEnumerable<Szakterulet> Szakteruletek => szakteruletek;

        DataStore()
        {
            ugyfelek = File.ReadAllLines("Input\\ugyfel.csv").Skip(1)
                .Select(x => new Ugyfel(x)).ToList();

            talalkozok = File.ReadAllLines("Input\\talalkozo.csv").Skip(1)
                .Select(x => new Talalkozo(x)).ToList();

            tanacsadok = File.ReadAllLines("Input\\tanacsado.csv").Skip(1)
                .Select(x => new Tanacsado(x)).ToList();

            szakteruletek = File.ReadAllLines("Input\\szakterulet.csv").Skip(1)
                .Select(x => new Szakterulet(x)).ToList();
        }

        public static DataStore? Instance { get; private set; }

        public static void InitCSV()
        {
            if (Instance is not null) throw new InvalidOperationException("Inicializáltál már");
            Instance = new DataStore();
        }

        public int TalalkozoAr(Talalkozo talalkozo)
        {
            Tanacsado? tanacsado = Tanacsadok.FirstOrDefault(x => x.ID == talalkozo.TanacsadoID);
            return tanacsado!.Oradij * talalkozo.Idotartam;
        }

        public int TalalkozokSzamaIdotartamAlapjan(int idotartam) => Talalkozok.Count(x => x.Idotartam >= idotartam);

        public Tanacsado TanacsadoNevAlapjan(string nev) => Tanacsadok.FirstOrDefault(x => x.Nev == nev)!;

        public Szakterulet SzakteruletIDAlapjan(int id) => Szakteruletek.FirstOrDefault(x => x.ID == id)!;

        public IEnumerable<(Tanacsado Tanacsado, int Kereset)> LegtobbPenztKeresok()
        {
            return
                Talalkozok
                .GroupBy(x => x.TanacsadoID)
                .Select(x => (
                    Tanacsado: Tanacsadok.First(y => y.ID == x.Key),
                    Kereset: x.Sum(y => TalalkozoAr(y))
                ))
                .OrderByDescending(x => x.Kereset)
                .Take(3);
        }
    }
}
