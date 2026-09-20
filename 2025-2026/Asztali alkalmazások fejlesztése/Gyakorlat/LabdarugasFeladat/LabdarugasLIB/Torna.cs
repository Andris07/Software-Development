using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabdarugasLIB
{
    public class Torna
    {
        // TornaID;Nev
        public int TornaID { get; init; }
        public string Nev { get; init; }

        public Torna(string fájlSor)
        {
            string[] adatok = fájlSor.Split(";");
            this.TornaID = int.Parse(adatok[0]);
            this.Nev = adatok[1];
        }

        // Számított tulajdonságok
        public Csapat VezetoCsapat => DataStore.Instance!.Csapatok.Where(x => x.TornaID == TornaID).MaxBy(x => x.TornaPontok)!;

        public override string ToString()
        {
            return $"A(z) {Nev} tornát jelenleg a(z) {VezetoCsapat.Nev} vezeti {VezetoCsapat.TornaPontok} ponttal.";
        }
    }
}
