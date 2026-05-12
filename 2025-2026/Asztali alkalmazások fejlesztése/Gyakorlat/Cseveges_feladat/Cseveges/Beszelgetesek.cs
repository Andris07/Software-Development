using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cseveges
{
    public class Beszelgetesek
    {
        private readonly List<Beszelgetes> beszelgetesek = new List<Beszelgetes>();

        public Beszelgetesek(IEnumerable<string> fajlSorok)
        {
            foreach (var fajlSor in fajlSorok)
            {
                beszelgetesek.Add(new Beszelgetes(fajlSor));
            }
        }

        public int BeszelgetesekSzama => beszelgetesek.Count();
        public Beszelgetes LeghosszabbBeszelgetes=> beszelgetesek.OrderByDescending(b => b.Hossz).First();

        public TimeSpan SzemelyOsszBeszelgetesenekIdeje(string keresettNev)
        {
            TimeSpan ossz = TimeSpan.Zero;
            List<Beszelgetes> keresettSzemelyBeszelgetesei = beszelgetesek.Where(b => b.Kezdemenyezo == keresettNev || b.Fogado == keresettNev).ToList();
            
            foreach (Beszelgetes beszelgetes in keresettSzemelyBeszelgetesei)
            {
                ossz += beszelgetes.Hossz;
            }
            return ossz;
        }

        public List<string> BeszelgetoFogadok => beszelgetesek.GroupBy(x => x.Fogado).Select(x => x.Key).ToList();
        public List<string> BeszelgetoKezdemenyezok=> beszelgetesek.GroupBy(x => x.Kezdemenyezo).Select(x => x.Key).ToList();
        
        public List<string> Beszelgetok()
        {
            List<string> beszelgetok = new List<string>(BeszelgetoFogadok);

            foreach (string nev in BeszelgetoKezdemenyezok)
            {
                if (!beszelgetok.Contains(nev))
                {
                    beszelgetok.Add(nev);
                }
            }
            return beszelgetok;
        }

        public List<Beszelgetes> RendezettBeszelgetesek => beszelgetesek.OrderBy(b => b.Kezdet).ToList();
    }
}
