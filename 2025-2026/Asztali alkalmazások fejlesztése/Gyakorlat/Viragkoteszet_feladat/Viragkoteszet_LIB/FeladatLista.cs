using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragkoteszet_LIB
{
    public class FeladatLista
    {
        List<Termek> feladatok = new List<Termek>();
        public List<Termek> feladatokLista => feladatok;

        public FeladatLista()
        {

        }

        public static FeladatLista operator +(FeladatLista feladatokLista, Termek hozzaadandoFeladat)
        {
            FeladatLista kibovitettFeladatokLista = feladatokLista;
            kibovitettFeladatokLista.feladatok.Add(hozzaadandoFeladat);
            return kibovitettFeladatokLista;
        }
    }
}
