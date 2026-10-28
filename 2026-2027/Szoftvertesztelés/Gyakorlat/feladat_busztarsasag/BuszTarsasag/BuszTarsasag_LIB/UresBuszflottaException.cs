using System;
using System.Collections.Generic;
using System.Text;

namespace BuszTarsasag_LIB
{
    public class UresBuszflottaException : Exception
    {
        public UresBuszflottaException() : base("Üres buszflotta!")
        {

        }
    }
}
