using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teremfoglalas_LIB
{
    public sealed class AltalanosTerem : Terem
    {
        public AltalanosTerem(string teremAzonosito, int helyekSzama) : base(teremAzonosito, helyekSzama)
        {

        }

        public override void IdoPontFoglalas(Foglalas foglalas)
        {
            TeremOrarend += foglalas;
        }

        public override string ToString()
        {
            return $"{TeremAzonosito}:\n{TeremOrarend}";
        }
    }
}
