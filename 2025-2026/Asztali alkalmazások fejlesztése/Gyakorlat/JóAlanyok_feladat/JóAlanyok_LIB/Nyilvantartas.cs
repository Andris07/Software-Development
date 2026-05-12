using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JóAlanyok_LIB
{
    public class Nyilvantartas
    {
        private readonly List<Szemely> szemelyek = new List<Szemely>();
        public IEnumerable<Szemely> Szemelyek => szemelyek;

        public Nyilvantartas(IEnumerable<string> fájlSorok)
        {
            foreach (var fájlSor in fájlSorok)
            {
                SzemelyFactory szemelyFactory = new SzemelyFactory();
                szemelyek.Add(szemelyFactory.Factory(fájlSor));
            }
        }

        public IEnumerable<Diak> Diakok => szemelyek.OfType<Diak>();
        public int DiakokSzama() => Diakok.Count();
        public IEnumerable<Tanar> Tanarok => szemelyek.OfType<Tanar>();
        public int TanarokSzama() => Tanarok.Count();
        public double AtlagTanarEletkor() => Tanarok.Average(x => x.Kor);
        public Dictionary<int, int> DiakokSzamaPuskakSzamaSzerint() => Diakok.GroupBy(x => x.PuskakSzama).ToDictionary(x => x.Key, x => x.Count());

        public Szemely this[int i]
        {
            get => szemelyek[i];
            set => szemelyek[i] = value;
        }
    }
}
