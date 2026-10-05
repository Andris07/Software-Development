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
        public FeladatLista feladatok = new FeladatLista();

        public Gyakornok(int dolgozoID, string dolgozoNev, IEnumerable<int> termekek) : base(dolgozoID, dolgozoNev)
        {
            this.termekAzonositok = termekek.ToList();
        }

        readonly int[] gyakorlottsagSzintek = new int[] { 70, 80, 90 };
        readonly static Random rnd = new Random();
        int szint = rnd.Next(0, 3);

        public int Gyakorlottsag => gyakorlottsagSzintek[szint];

        public int MunkaraForditottIdo
        {
            get
            {
                int munkaraForditottIdo = 0;

                foreach (var feladat in feladatok.feladatokLista)
                {
                    if (termekAzonositok.Contains(feladat.ID))
                    {
                        munkaraForditottIdo += feladat.ElkeszitesiIdo * 1 + (100 - Gyakorlottsag);
                    }
                }
                return munkaraForditottIdo;
            }
        }

        public void UjFeladatHozzaadasa(Termek hozzaadandoFeladat)
        {
            bool tartalmazza = feladatok.feladatokLista.Select(x => x.ID).Contains(hozzaadandoFeladat.ID);
            if (!tartalmazza)
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
