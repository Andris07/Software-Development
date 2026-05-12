using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public class FeladatLista
    {
        List<string> feladatok = new List<string>();
        public List<string> feladatokLista => feladatok;

        public FeladatLista()
        {

        }

        public static FeladatLista operator +(FeladatLista feladatokLista, string hozzaadandoFeladat)
        {
            FeladatLista kibovitettFeladatokLista = feladatokLista;
            kibovitettFeladatokLista.feladatok.Add(hozzaadandoFeladat);
            return kibovitettFeladatokLista;
        }
    }
}
