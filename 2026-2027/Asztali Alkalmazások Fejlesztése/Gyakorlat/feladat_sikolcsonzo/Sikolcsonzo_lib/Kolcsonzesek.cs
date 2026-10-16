using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sikolcsonzo_lib
{
    public class Kolcsonzesek
    {
        public List<Sporteszkoz> Sportszerek {  get; init; }

        public Kolcsonzesek(List<Sporteszkoz>sportszerek)
        {
            Sportszerek = sportszerek;
        }

        public string[] Leirasok => Sportszerek.Select(x => x.Leiras).ToArray();

        public Sporteszkoz this[string azonosito] => Sportszerek.FirstOrDefault(x=>x.Azonosito == azonosito)!;

        public List<string> SporteszkozBerles(IEnumerable<string> igenyek)
        {
            List<string> hibak = new();
            foreach(string igeny in igenyek){
                try
                {
                    //Kezdet;Napok;EszkozID;Berlo
                    string[] adatok = igeny.Split(';');
                    Sportszerek.Where(x => x.Azonosito == adatok[2]).First().Foglalasok+=new Berles(adatok[2], DateOnly.Parse(adatok[0]), int.Parse(adatok[1]), adatok[3]);
                }
                catch (Exception ex)
                {
                    hibak.Add(ex.Message + " - " + igeny);
                }
            }
            return hibak;
        }

        public IEnumerable<Sporteszkoz> SzabadSporteszkozok(DateOnly kezdes, int ido)
        {
            List<Sporteszkoz> eszkozok = new List<Sporteszkoz>();
            foreach (Sporteszkoz eszkoz in Sportszerek)
            {
                if (eszkoz.Foglalasok.SzabadE(kezdes, ido))
                {
                    eszkozok.Add(eszkoz);
                }
            }
            return eszkozok;
        }
    }
}
