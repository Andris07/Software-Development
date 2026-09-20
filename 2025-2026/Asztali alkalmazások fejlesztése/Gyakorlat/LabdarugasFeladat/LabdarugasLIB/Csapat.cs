using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabdarugasLIB
{
    public class Csapat
    {
        // CsapatID;Nev;EdzoID;Trofeak;TornaID;TornaPontok
        public int CsapatID { get; init; }
        public string Nev { get; init; }
        public int EdzoID { get; init; }
        public int Trofeak { get; init; }
        public int TornaID { get; init; }
        public int TornaPontok { get; init; }

        public Csapat(string fájlSor)
        {
            string[] adatok = fájlSor.Split(";");
            this.CsapatID = int.Parse(adatok[0]);
            this.Nev = adatok[1];
            this.EdzoID = int.Parse(adatok[2]);
            this.Trofeak = int.Parse(adatok[3]);
            this.TornaID = int.Parse(adatok[4]);
            this.TornaPontok = int.Parse(adatok[5]);
        }

        // Számított tulajdonságok (TODO)
        public Edzo? Edzo => DataStore.Instance!.Edzok.FirstOrDefault(x => x.EdzoID == EdzoID);
        public Torna? Torna => DataStore.Instance!.Tornak.FirstOrDefault(x => x.TornaID == TornaID);

        public override string ToString()
        {
            return $"A(z) {Nev} csapat megalapulása óta {Trofeak} trófeával büszkélkedhet, melyhez jelenlegi edzőjük ({Edzo!.Nev}) összesen {Edzo.Trofeak} trófeával járult hozzá. Jelenleg a {Torna!.Nev} tornában {TornaPontok} ponttal küzdenek azért, hogy bejussanak az egyenes kieséses szakaszba.";
        }
    }
}
