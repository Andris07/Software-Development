using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halmaz_LIB
{
    public static class FajlKezelo
    {
        public static List<Szemely> FajlBeolvasas(string fajlNev)
        {
            IEnumerable<string> fajlSorok = File.ReadAllLines(fajlNev);
            List<Szemely> lista = new List<Szemely>();

            foreach (var sor in fajlSorok.Skip(1))
            {
                var adatok = sor.Split(";");

                if (adatok[2] == "T")
                    lista.Add(new Tanar(adatok[0], adatok[1], adatok[2], adatok[3]));
                else
                    lista.Add(new Diak(adatok[0], adatok[1], adatok[2], adatok[3]));
            }

            return lista;
        }
    }
}
