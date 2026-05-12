using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas_Jatekgyar_LIB
{
    public class Feladatok
    {
        public IEnumerable<Feladat> FeladatLista => feladatLista;
        readonly List<Feladat> feladatLista;

        public Feladatok()
        {
            feladatLista = new List<Feladat>();
        }

        public static Feladatok operator +(Feladatok eddigiFeladatok, Feladat ujFeladat)
        {
            var ujFeladatLista = new Feladatok();
            ujFeladatLista.feladatLista.AddRange(eddigiFeladatok.feladatLista);
            ujFeladatLista.feladatLista.Add(ujFeladat);
            return ujFeladatLista;
        }

        public Dictionary<string, int> FeladatokOsszmennyisege()
        {
            return feladatLista.GroupBy(x => x.JatekTipus.Megnevezes).ToDictionary(x => x.Key, x => x.Sum(y => y.Darabszam));
        }
    }
}
