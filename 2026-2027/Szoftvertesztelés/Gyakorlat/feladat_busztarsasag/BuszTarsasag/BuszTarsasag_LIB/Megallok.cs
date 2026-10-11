using System;
using System.Collections.Generic;
using System.Text;

namespace BuszTarsasag_LIB
{
    public class Megallok
    {
        readonly List<Megallo> megalloHelyek = new List<Megallo>();
        public List<Megallo> MegalloHelyek => megalloHelyek;

        public Megallok(Dictionary<string, int> megalloAdatok)
        {
            foreach (var megallo in megalloAdatok)
            {
                megalloHelyek.Add(new Megallo(megallo.Key, megallo.Value));
            }
        }

        public bool ErvenytelenMegallo()
        {
            foreach (var megallo in megalloHelyek)
            {
                if (megallo.MegallobanVarakozoEmberekSzamaErvenytelen(megallo.MegallobanVarakozoEmberek))
                    return true;
            }
            return false;
        }
    }
}
