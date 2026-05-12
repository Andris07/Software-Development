using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teremfoglalas_LIB
{
    public static class TeremFactory
    {
        public static Terem TeremLetrehozas(string adatsor)
        {
            string[] adatok = adatsor.Split(";");
            return adatok[0] switch
            {
                "a" => new AltalanosTerem(adatok[1], int.Parse(adatok[2])),
                "s" => new SpecialisTerem(adatok[1], int.Parse(adatok[3]), int.Parse(adatok[3])),
                _ => throw new ArgumentException()
            };
        }
    }
}
