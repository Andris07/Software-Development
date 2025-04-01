using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KincsesLada
{
    class Dragako : IKincs
    {
        enum Fajta
        {
            zafír, smaragd, gyémánt
        }

        static Dictionary<string, int> ar = new Dictionary<string, int>()
        {
            {"zafír", 500 },
            {"smaragd", 400 },
            {"gyémánt", 1000 }
        };

        public string Nev => Tipus;

        public string Leiras => $"Egy gyönyörű {Meret}méretű {Tipus}.";

        public int Ertek => ar[Tipus]*Nagysag*Nagysag;

        public string Meret { get; }

        public int Nagysag { get; }

        public string Tipus { get; }
        public Dragako(int tipus, int nagysag)
        {
            Tipus = ((Fajta)tipus).ToString();
            Nagysag = nagysag+1;
            Meret = nagysag switch
            {
                0 => "kis",
                1 => "közepes ",
                2 => "nagy",
                _ => throw new NotImplementedException()
            };
        }

        public override string ToString()
        {
            return Leiras;
        }
    }
}
