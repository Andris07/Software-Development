using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teremfoglalas_LIB
{
    public abstract class Terem
    {
        public string TeremAzonosito { get; init; }
        public int HelyekSzama { get; init; }
        public Orarend TeremOrarend { get; protected set; }

        protected Terem(string teremAzonosito, int helyekSzama)
        {
            this.TeremAzonosito = teremAzonosito;
            this.HelyekSzama = helyekSzama;
            this.TeremOrarend = new Orarend();
        }

        public abstract void IdoPontFoglalas(Foglalas foglalas);
    }
}
