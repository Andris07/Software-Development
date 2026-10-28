using System;
using System.Collections.Generic;
using System.Text;

namespace BuszTarsasag_LIB
{
    public class Megallo
    {
        public string Nev { get; init; }
        public int MegallobanVarakozoEmberek { get; private set; }
        public int FelszalltOsszesen { get; private set; }
        public int LeszalltOsszesen { get; private set; }

        public Megallo(string nev, int megallobanVarakozoEmberek)
        {
            Nev = nev;
            MegallobanVarakozoEmberek = megallobanVarakozoEmberek;
        }

        public bool UtasCsere(int buszraFelszalloEmberek, int buszrolLeszalloEmberek)
        {
            if (buszraFelszalloEmberek < 0 || buszrolLeszalloEmberek < 0)
                return false;

            // való életben is először leszállnak az emberek a buszról és a megállóban kötnek ki, míg a felszállók ezt megvárják a megállóban, majd felszállnak, elhagyva a megállót
            int ujVarakozoEmberek = MegallobanVarakozoEmberek + buszrolLeszalloEmberek - buszraFelszalloEmberek;

            if (MegallobanVarakozoEmberekSzamaErvenytelen(ujVarakozoEmberek))
                return false;

            MegallobanVarakozoEmberek = ujVarakozoEmberek;
            FelszalltOsszesen += buszraFelszalloEmberek;
            LeszalltOsszesen += buszrolLeszalloEmberek;

            return true;
        }

        public bool MegallobanVarakozoEmberekSzamaErvenytelen(int megallobanVarakozoEmberek)
        {
            // megállóban várakozó emberek száma nem lehet negatív, ELVILEG úgy nem tud senki sem leszállni a buszról a megállóba, hogy közben a buszon marad és csökkenti a megállóban várakozók számát leszállás után
            return megallobanVarakozoEmberek < 0;
        }
    }
}
