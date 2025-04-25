using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Szankok
{
    internal class Szanko
    {
        private int letszam;
        private int allapot;
        private int maxTeherBiras;

        public bool UresE
        {
            get
            {
                return UresE;
            }
            set
            {
                if (letszam == 0)
                {
                    UresE = true;
                }
                else
                {
                    UresE = false;
                }
            }
        }

        public int Letszam
        {
            get
            {
                return letszam;
            }
            set
            {
                if (value < 0 || value > 3)
                {
                    letszam = 0;
                }
                else
                {
                    letszam = value;
                }
            }
        }

        public int Allapot
        {
            get
            {
                return allapot;
            }
            set
            {
                if (value < 0)
                {
                    allapot = 0;
                }
                else if (value > 100)
                {
                    allapot = 100;
                }
                else
                {
                    allapot = value;
                }
            }
        }

        public int Terheles { get; private set; }

        public int MaxTeherBiras
        {
            get
            {
                return maxTeherBiras;
            }
            private set
            {
                if (value < 0)
                {
                    maxTeherBiras = 0;
                }
                else if (value > 200)
                {
                    maxTeherBiras = 200;
                }
                else
                {
                    maxTeherBiras = value;
                }
            }
        }

        public Szanko()
        {
            Random r = new Random();
            letszam = 0;
            allapot = r.Next(50, 101);
            Terheles = 0;
            maxTeherBiras = r.Next(100, 201);
        }

        public Szanko(int maxTeherBiras)
        {
            Random r = new Random();
            letszam = 0;
            allapot = r.Next(50, 101);
            Terheles = 0;
            this.maxTeherBiras = maxTeherBiras;
        }

        public string Log()
        {
            return $"A szánkó terhelése: {Terheles} állapota: {allapot}%";
        }

        public bool FelUlValaki(int suly)
        {
            if (letszam < 3)
            {
                letszam++;
                Terheles += suly;
                if (Terheles > maxTeherBiras)
                {
                    allapot = 0;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Csuszas()
        {
            if (letszam != 0)
            {
                allapot = Terheles*3/maxTeherBiras;
            }
            letszam = 0;
            Terheles = 0;
            return $"Nem ül senki a szánkón";
        }

        public int Javitas(int ertek)
        {
            allapot += ertek;
            Terheles = 0;
            return allapot;
        }
    }
}
