using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace Teasdobozok_LIB
{
    public sealed class ValogatasDoboz : TeasDoboz
    {
        readonly Filterek filterekTeljesLista;
        public List<string> FilterTipusok { get; private set; }

        public ValogatasDoboz(int darabSzam, Filterek filterekTeljesLista) : base(darabSzam)
        {
            this.filterekTeljesLista = filterekTeljesLista;
            this.FilterTipusok = new List<string>();
        }

        public override int Ar
        {
            get
            {
                int ar = 0;

                foreach(var filterTipus in FilterTipusok)
                {
                    Filter filter = filterekTeljesLista.filterekLista.Where(x => x.Tipus == filterTipus).FirstOrDefault()!;
                    ar += filter.Ar * DarabSzam;
                }
                return ar + 100;
            }
        }

        public string FilterTipusokString => String.Join(", ", FilterTipusok.Distinct());
        public override string Nev => $"Válogatás tea ({FilterTipusokString})";

        public static ValogatasDoboz operator +(ValogatasDoboz regiValogatasDoboz, Filter? filter)
        {
            if (filter is null) throw new HibasAzonositoException();
            ValogatasDoboz ujValogatasDoboz = new ValogatasDoboz(regiValogatasDoboz.DarabSzam, regiValogatasDoboz.filterekTeljesLista);
            ujValogatasDoboz.FilterTipusok.AddRange(regiValogatasDoboz.FilterTipusok);
            ujValogatasDoboz.FilterTipusok.Add(filter.Tipus);
            return ujValogatasDoboz;
        }
    }
}