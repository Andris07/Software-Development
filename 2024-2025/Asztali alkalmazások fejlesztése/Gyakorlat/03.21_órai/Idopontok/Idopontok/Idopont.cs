using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idopontok
{
    internal class Idopont
    {
        private int ora;
        private int perc;
        private int masodPerc;

        public int Ora
        {
            get
            {
                return ora;
            }
            set
            {
                if (value < 0 || value > 23)
                {
                    ora = 0;
                }
                else
                {
                    ora = value;
                }
            }
        }

        public int Perc
        {
            get
            {
                return perc;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    perc = 0;
                }
                else
                {
                    perc = value;
                }
            }
        }

        public int MasodPerc
        {
            get
            {
                return masodPerc;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    masodPerc = 0;
                }
                else
                {
                    masodPerc = value;
                }
            }
        }

        public bool Delelott
        {
            get
            {
                if (ora < 12)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Idopont()
        {
            Random r = new Random();
            ora = r.Next(0, 24);
            perc = r.Next(0, 60);
            masodPerc = r.Next(0, 60);
        }


        public Idopont(int ora, int perc, int masodPerc)
        {
            Ora = ora;
            Perc = perc;
            MasodPerc = masodPerc;
        }

        public int HanyPercEddig()
        {
            return ora * 60 + perc;
        }

        public int HanyMasodPercEddig()
        {
            return ora * 60 * 60 + masodPerc;
        }

        public string Megjelenites()
        {
            return $"{ora}:{perc}:{masodPerc} az idő, vagyis a nap kezdetétől {HanyPercEddig()} perc, valamint {HanyMasodPercEddig()} másodperc telt el eddig";
        }
    }
}
