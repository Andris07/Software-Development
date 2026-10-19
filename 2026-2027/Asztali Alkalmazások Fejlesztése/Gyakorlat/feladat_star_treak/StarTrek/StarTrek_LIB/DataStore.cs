using System;
using System.Collections.Generic;
using System.Text;

namespace StarTrek_LIB
{
    public class DataStore
    {
        readonly List<Fajok> fajok;
        readonly List<HajoOsztalyok> hajoOsztalyok;
        readonly List<HajoSzerepek> hajoSzerepek;
        readonly List<Urhajok> urhajok;

        public IEnumerable<Fajok> Fajok => fajok;
        public IEnumerable<HajoOsztalyok> HajoOsztalyok => hajoOsztalyok;
        public IEnumerable<HajoSzerepek> HajoSzerepek => hajoSzerepek;
        public IEnumerable<Urhajok> Urhajok => urhajok;

        DataStore()
        {
            fajok = File.ReadAllLines("Input\\fajok.csv").Skip(1)
                .Select(x => new Fajok(x)).ToList();

            hajoOsztalyok = File.ReadAllLines("Input\\hajo_osztalyok.csv").Skip(1)
                .Select(x => new HajoOsztalyok(x)).ToList();

            hajoSzerepek = File.ReadAllLines("Input\\hajo_szerepek.csv").Skip(1)
                .Select(x => new HajoSzerepek(x)).ToList();

            urhajok = File.ReadAllLines("Input\\urhajok.csv").Skip(1)
                .Select(x => new Urhajok(x)).ToList();
        }

        public static DataStore? Instance { get; private set; }

        public static void InitCSV()
        {
            if (Instance is not null) throw new InvalidOperationException("Inicializáltál már!");
            DataStore.Instance = new DataStore();
        }

        public int HanyUrhajoTartalmazza(string szo) => Urhajok.Count(x => x.Nev.Contains(szo));

        public HajoSzerepek SzerepNevAlapjan(string nev) => HajoSzerepek.FirstOrDefault(x => x.Nev == nev)!;

        public int HanyHajoSzerepRendelteteseAzAdottSzerep(HajoSzerepek szerep) => hajoOsztalyok.Count(x => x.SzerepID == szerep.ID);

        public IEnumerable<(HajoOsztalyok HajoOsztaly, int Darab)> LegtobbUrhajovalRendelkezoHajoOsztaly()
        {
            return
                urhajok.GroupBy(x => x.OsztalyID)
                .Select(x => (
                    HajoOsztaly: HajoOsztalyok.First(y => y.ID == x.Key),
                    Darab: x.Count()
                ))
                .OrderByDescending(x => x.Darab)
                .Take(3);
        }
    }
}