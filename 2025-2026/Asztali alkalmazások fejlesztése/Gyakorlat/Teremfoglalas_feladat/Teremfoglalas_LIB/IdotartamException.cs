using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teremfoglalas_LIB
{
    public class IdotartamException : Exception
    {
        public IdotartamException() : base("A lefoglalt időtartam nem pozitív, vagy nem 15-tel osztható.")
        {
            
        }
    }
}
