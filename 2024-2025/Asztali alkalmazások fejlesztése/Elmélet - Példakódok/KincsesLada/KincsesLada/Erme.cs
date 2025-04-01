using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KincsesLada
{
    class Erme : IKincs
    {
        enum Fajta 
        {
            arany, ezüst, réz
        }

        static Dictionary<string, int> ar = new Dictionary<string, int>()
        {
            {"arany", 100 },
            {"ezüst", 10 },
            {"réz", 1 }
        };

        public string Nev => "érme";

        public string Leiras => $"Egy csillogó {Tipus}érme.";

        public string Tipus { get; }

        public int Ertek => ar[Tipus];

        public Erme(int tipus)
        {
            Tipus = ((Fajta)tipus).ToString();
        }

        public override string ToString()
        {
            return Leiras;
        }
    }
}
