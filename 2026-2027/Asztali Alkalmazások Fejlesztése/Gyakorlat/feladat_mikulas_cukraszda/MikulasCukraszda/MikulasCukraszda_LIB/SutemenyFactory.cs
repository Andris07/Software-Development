using System;
using System.Collections.Generic;
using System.Text;

namespace MikulasCukraszda_LIB
{
    public static class SutemenyFactory
    {
        public static Sutemeny Factory(string fajlSor, KeszitesAdatok keszitesAdatok)
        {
            string[] adatok = fajlSor.Split(";");

            if (adatok[1] == "f")
            {
                return new DiszitettSutemeny(adatok[0], adatok[1], adatok[2], keszitesAdatok, adatok.Skip(3));
            }
            else
            {
                return new AlapSutemeny(adatok[0], adatok[1], adatok[2], keszitesAdatok);
            }
        }
    }
}
