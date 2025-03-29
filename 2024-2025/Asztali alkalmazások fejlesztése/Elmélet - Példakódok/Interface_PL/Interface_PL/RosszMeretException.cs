using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_PL
{
    internal class RosszMeretException : Exception
    {
        public RosszMeretException(string mezo = null) 
            : base($"A megadott {mezo} nem pozitív")
        {
            
        }
    }
}
