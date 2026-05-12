using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teremfoglalas_LIB
{
    public sealed class SpecialisTerem : Terem
    {
        public int TakaritasiIdo { get; init; }

        public SpecialisTerem(string teremAzonosito, int helyekSzama, int takaritasiIdo) : base(teremAzonosito, helyekSzama)
        {
            this.TakaritasiIdo = takaritasiIdo;
        }

        public override void IdoPontFoglalas(Foglalas foglalas)
        {
            Foglalas takaritas = new Foglalas(foglalas.Vege, TakaritasiIdo, TeremAzonosito, "takaritas");
            TeremOrarend = TeremOrarend + foglalas + takaritas;
        }

        public override string ToString()
        {
            return $"{TeremAzonosito} (takarítási idő: {TakaritasiIdo} perc):\n{TeremOrarend}";
        }
    }
}
