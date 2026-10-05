using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_LIB
{
    public class KeszitesAdatok
    {
        readonly List<KeszitesAdat> keszitesAdatok = new List<KeszitesAdat>();

        public KeszitesAdatok(IEnumerable<string> fajlSorok)
        {
            foreach (string fajlSor in fajlSorok)
            {
                string[] adatok = fajlSor.Split(";");
                keszitesAdatok.Add(new KeszitesAdat(adatok[0], adatok[1], int.Parse(adatok[2])));
            }
        }

        public KeszitesAdat this[string azonosito] => keszitesAdatok.FirstOrDefault(x => x.Azonosito == azonosito)!;

        public IEnumerable<string> ElerhetoKeszitesAzonositok => keszitesAdatok.Select(x => x.Azonosito).Order();
    }
}
