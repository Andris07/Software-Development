using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public class Gyakornok : Dolgozo
    {
        readonly List<int> termekAzonositok = new List<int>();
        static readonly int[] gyakorlottsagSzintek = new int[] { 70, 80, 90 };
        static readonly Random rnd = new Random();

        public override double Gyakorlottsag { get; }

        public Gyakornok(int dolgozoID, string dolgozoNev, IEnumerable<int> termekek) : base(dolgozoID, dolgozoNev)
        {
            this.termekAzonositok = termekek.ToList();
            this.Gyakorlottsag = gyakorlottsagSzintek[rnd.Next(0, gyakorlottsagSzintek.Length)];
        }

        public override int MunkaraForditottIdo
        {
            get
            {
                double munkaraForditottIdo = 0;

                foreach (var feladat in feladatok.feladatokLista)
                {
                    munkaraForditottIdo += feladat.ElkeszitesiIdo * (1 + (100 - Gyakorlottsag) / 100.0);
                }
                return (int)Math.Round(munkaraForditottIdo);
            }
        }

        public override void UjFeladatHozzaadasa(Termek hozzaadandoFeladat)
        {
            if (!termekAzonositok.Contains(hozzaadandoFeladat.ID))
            {
                throw new HibasFeladatException();
            }
            feladatok += hozzaadandoFeladat;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nGyakornok neve: {DolgozoNev}";
        }
    }
}
