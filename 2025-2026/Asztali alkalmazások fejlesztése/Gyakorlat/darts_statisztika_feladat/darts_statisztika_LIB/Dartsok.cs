using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darts_statisztika_LIB
{
    public class Dartsok
    {
        List<Darts> dartsok = new List<Darts>();

        public Dartsok(IEnumerable<string> FajlSorok)
        {
            foreach (string FajlSor in FajlSorok)
            {
                string[] sor = FajlSor.Split(';');
                int jatekosSzam = int.Parse(sor[0]);
                string elsoDobas = sor[1];
                string masodikDobas = sor[2];
                string harmadikDobas = sor[3];

                dartsok.Add(new Darts(jatekosSzam, elsoDobas, masodikDobas, harmadikDobas));
            }
        }

        public int korokSzama() => dartsok.Count();
        public int harmadikDobasraBullseye() => dartsok.Count(x => x.HarmadikDobas == "D25");
        public int szektoronkentiJatekosDobasanakSzama(int jatekosSzam, string szektor) => dartsok.Count(x => x.JatekosSzam == jatekosSzam && (x.ElsoDobas.Contains(szektor) || x.MasodikDobas.Contains(szektor) || x.HarmadikDobas.Contains(szektor)));
        public int koronkentiJatekosDobasanakErtekenekSzama(int jatekosSzam, string ertek) => dartsok.Count(x => x.JatekosSzam == jatekosSzam && x.ElsoDobas == ertek && x.MasodikDobas == ertek && x.HarmadikDobas == ertek);
    }
}