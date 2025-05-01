using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Varosok_LIB
{
    public class Varosok
    {
        private readonly List<Varos> varosok = [];

        public Varosok(IEnumerable<string> fajlSorok)
        {
            foreach (var fajlSor in fajlSorok)
            {
                varosok.Add(new Varos(fajlSor));
            }
        }

        public int VarosokSzama => varosok.Count;
        public double OrszagVarosainakLakossaga(string orszag) => varosok.Where(x => x.OrszagNev == orszag).Sum(x => x.LakossagSzama);
        public Varos LegnagyobbLakossaguVaros => varosok.MaxBy(x => x.LakossagSzama);
        public bool VanEVarosa(string orszag) => varosok.Any(x => x.OrszagNev == orszag);
        public IEnumerable<string> OrszagVarosai(string orszag) => varosok.Where(x => x.OrszagNev == orszag).Select(x => x.VarosNev).Distinct();
        public int NepessegetEleroVarosokSzama(int nepesseg) => varosok.Count(x => x.LakossagSzama >= nepesseg);
        public IEnumerable<string> OrszagokNevei => varosok.Select(x => x.OrszagNev).Distinct().Order();
        public IEnumerable<Varos> LegnagyobbVarosok(int darabSzam) => varosok.OrderByDescending(x => x.LakossagSzama).Take(darabSzam);
    }
}