using System;
using System.Collections.Generic;
using System.Text;

namespace Hanoi_LIB
{
    public class NemTehetőÁtException : Exception
    {
        public NemTehetőÁtException() : base("Nem tudsz erre a rúdra pakolni")
        {

        }
    }
}
