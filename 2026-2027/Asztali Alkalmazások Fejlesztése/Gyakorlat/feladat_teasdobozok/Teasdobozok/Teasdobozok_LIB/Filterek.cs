using System;
using System.Collections.Generic;
using System.Text;

namespace Teasdobozok_LIB
{
    public class Filterek
    {
        readonly List<Filter> filterek = new List<Filter>();
        public List<Filter> filterekLista => filterek;

        public Filterek(IEnumerable<string> fájlSorok)
        {
            foreach(var fájlSor in fájlSorok)
            {
                string[] adatok = fájlSor.Split(";");
                filterek.Add(new Filter(adatok[0], adatok[1], int.Parse(adatok[2])));
            }
        }

        public Filter this[string id] => filterek.FirstOrDefault(x => x.ID == id)!;

        public IEnumerable<Filter> Gyogynovenyek => filterek.Where(x => x.Gyogytea).OrderBy(x => x.Tipus);
        public IEnumerable<string> GyogynovenyFilterek => Gyogynovenyek.Select(x => x.Tipus);
    }
}
