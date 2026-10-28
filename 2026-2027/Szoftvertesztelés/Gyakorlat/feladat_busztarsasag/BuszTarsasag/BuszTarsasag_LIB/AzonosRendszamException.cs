using System;
using System.Collections.Generic;
using System.Text;

namespace BuszTarsasag_LIB
{
    public class AzonosRendszamException : Exception
    {
        public AzonosRendszamException() : base("Ilyen rendszámú busz már létezik!")
        {

        }
    }
}
