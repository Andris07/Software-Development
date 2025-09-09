using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace hataratkelok_LIB
{
    public class Hataratkelok
    {
        List<Hataratkelo> hataratkelok = new List<Hataratkelo>();

        public Hataratkelok(IEnumerable<string> fajlSorok)
        {
            foreach (string fajlSor in fajlSorok.Skip(1))
            {
                string[] sor = fajlSor.Split(';');
                string telepulesNev = sor[0];
                string telepulesTipus = sor[1];
                string megye = sor[2];
                string szomszedTelepules = sor[3];
                string orszag = sor[4];
                string atkeloTipus = sor[5];

                hataratkelok.Add(new Hataratkelo(telepulesNev, telepulesTipus, megye, szomszedTelepules, orszag, atkeloTipus));
            }
        }

        public int hatarAtkelok_db() => hataratkelok.Count();
        public int vasutAtkelok_db() => hataratkelok.Count(x => x.AtkeloTipus == "vasúti");
        public IEnumerable<Hataratkelo> megyeJoguVarosAtkelok() => hataratkelok.Where(x => x.TelepulesTipus == "megyei jogú város");
        public int varosVagyMegyeJoguAusztriabaVezetoAtkelok_db() => hataratkelok.Count(x => (x.TelepulesTipus == "város" || x.TelepulesTipus == "megyei jogú város") && x.Orszag == "Ausztria");
        public string elsoAusztriabaVezetoAtkelo() => hataratkelok.OrderBy(x => x.TelepulesNev).First(x => x.Orszag == "Ausztria").TelepulesNev;
        public List<string> magyarorszagraVezetoAtkelokOrszagai() => hataratkelok.Where(x => x.Orszag != "Magyarország").OrderBy(x => x.Orszag).Select(x => x.Orszag).Distinct().ToList();
        public IEnumerable<string> kozutiEsVasutiAtkelokVarosai() => hataratkelok.OrderBy(x => x.TelepulesNev).GroupBy(x => x.TelepulesNev).Where(x => x.DistinctBy(y => y.AtkeloTipus).Count() >= 2).Select(x => x.Key);
        public Dictionary<string, int> orszagokAtkeloi_db() => hataratkelok.GroupBy(x => x.Orszag).ToDictionary(x => x.Key, x => x.Count());
        public IEnumerable<Hataratkelo> megyenkentiAtkelok(string megye) => hataratkelok.Where(x => x.Megye == megye);
    }
}
