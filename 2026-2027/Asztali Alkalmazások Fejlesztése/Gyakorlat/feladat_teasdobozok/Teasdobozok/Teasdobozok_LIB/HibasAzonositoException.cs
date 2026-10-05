using System;
using System.Collections.Generic;
using System.Text;

namespace Teasdobozok_LIB
{
    public class HibasAzonositoException : Exception
    {
        public HibasAzonositoException() : base("A megadott filter azonosító nem létezik.")
        {

        }
    }
}
