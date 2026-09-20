using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ForditoIrodaLIB
{
    public class Adatok
    {
        readonly List<Fordito> forditok = new List<Fordito>();
        readonly List<Nyelv> nyelvek = new List<Nyelv>();
        readonly List<Megrendeles> megrendelesek = new List<Megrendeles>();

        public void Beolvasas(IEnumerable<string> fajlSorok, int beolvasandoCSVSorszam)
        {
            foreach (var fajlSor in fajlSorok.Skip(1))
            {
                switch (beolvasandoCSVSorszam)
                {
                    case 1:
                        this.forditok.Add(new Fordito(fajlSor)); break;
                    case 2:
                        this.nyelvek.Add(new Nyelv(fajlSor)); break;
                    case 3:
                        this.megrendelesek.Add(new Megrendeles(fajlSor)); break;
                }
            }
        }

        public List<Fordito> Forditok => forditok;
        public List<Nyelv> Nyelvek => nyelvek;
        public List<Megrendeles> Megrendelesek => megrendelesek;

        public int? MegrendelesOsszeg(int megrendelesID)
        {
            Megrendeles megrendeles = megrendelesek.FirstOrDefault(x => x.MegrendelesID == megrendelesID)!;
            int forditoID = megrendeles.ForditoID;
            Fordito fordito = forditok.FirstOrDefault(x => x.ForditoID == forditoID)!;
            int? megrendelesOsszeg = megrendeles.Oldalszam * fordito.ForditasDij;

            if (megrendelesOsszeg != null) return megrendelesOsszeg;
            return null;
        }

        public int ForditasokAdottEvAdottHonapban(int ev, int honap) => megrendelesek.Count(x => x.Datum.Year == ev && x.Datum.Month == honap);
        public IEnumerable<Fordito> forditokMegrendelesekAlapjanSorrendben() => forditok.OrderByDescending(f => megrendelesek.Count(m => m.ForditoID == f.ForditoID));
        public IEnumerable<Fordito> forditokKeresettPenzAlapjanSorrendben() => forditok.OrderByDescending(f => megrendelesek.Where(m => m.ForditoID == f.ForditoID).Sum(m => MegrendelesOsszeg(m.MegrendelesID)));
    }
}
