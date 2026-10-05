using System;
using System.Collections.Generic;
using System.Text;

namespace Teasdobozok_LIB
{
    public sealed class EgyszeruDoboz : TeasDoboz
    {
        readonly Filterek filterek;
        public Filter filterDobozban { get; init; }

        public EgyszeruDoboz(int darabSzam, string id, Filterek filterekTeljesLista) : base(darabSzam)
        {
            this.filterek = filterekTeljesLista;
            this.filterDobozban = filterek[id] ?? throw new HibasAzonositoException();
        }

        public override int Ar => filterDobozban.Ar * DarabSzam + 100;
        public override string Nev => $"{filterDobozban.Tipus} tea";
    }
}
