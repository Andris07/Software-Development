using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teremfoglalas_LIB
{
    public interface IFoglalas
    {
        string HelyszinAzonosito { get; }
        DateTime Kezdete { get; }
        DateTime Vege { get; }
    }
}
