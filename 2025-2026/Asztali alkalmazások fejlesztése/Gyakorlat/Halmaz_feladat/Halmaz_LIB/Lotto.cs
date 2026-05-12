using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halmaz_LIB
{
    public static class Lotto
    {
        static Random r = new Random();

        public static RendezettHalmaz<int> Sorsolas(int db, int max)
        {
            RendezettHalmaz<int> lotto = new RendezettHalmaz<int>();

            while (lotto.listaDB < db)
            {
                int szam = r.Next(1, max + 1);
                lotto.HozzaAd(szam);
            }

            return lotto;
        }
    }
}
