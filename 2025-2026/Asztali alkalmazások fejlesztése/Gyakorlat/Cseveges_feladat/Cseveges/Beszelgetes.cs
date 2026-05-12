using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cseveges
{
    public class Beszelgetes
    {
        public DateTime Kezdet { get; init; }
        public DateTime Veg { get; init; }
        public string Kezdemenyezo { get; init; }
        public string Fogado { get; init; }

        public TimeSpan Hossz => Veg - Kezdet;

        public Beszelgetes(string fajlSor)
        {
            var adatok = fajlSor.Split(";");
            this.Kezdet = DateTime.ParseExact(adatok[0].Trim(), "yy.MM.dd-HH:mm:ss", null);
            this.Veg = DateTime.ParseExact(adatok[1].Trim(), "yy.MM.dd-HH:mm:ss", null);
            this.Kezdemenyezo = adatok[2].Trim();
            this.Fogado = adatok[3].Trim();
        }
    }
}
