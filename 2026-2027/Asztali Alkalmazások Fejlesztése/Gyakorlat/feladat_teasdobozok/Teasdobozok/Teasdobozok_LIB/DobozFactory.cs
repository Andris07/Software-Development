using System;
using System.Collections.Generic;
using System.Text;

namespace Teasdobozok_LIB
{
    public class DobozFactory
    {
        // Darabszam;Filterek
        public int Darabszam { get; init; }
        public Filterek Filterek { get; init; }

        public static TeasDoboz Factory(string fájlSor, Filterek filterekTeljesLista)
        {
            string[] adatok = fájlSor.Split(";");
            int darabszam = int.Parse(adatok[0]);
            string[] azonositok = adatok.Skip(1).ToArray();

            if (azonositok.Length > 1)
            {
                ValogatasDoboz doboz = new ValogatasDoboz(darabszam / (adatok.Length - 1), filterekTeljesLista);

                foreach (string azonosito in azonositok)
                {
                    Filter filter = filterekTeljesLista.filterekLista.FirstOrDefault(x => x.ID == azonosito)!;
                    doboz += filter;
                }
                return doboz;
            }
            else
            {
                EgyszeruDoboz doboz = new EgyszeruDoboz(darabszam, adatok[1], filterekTeljesLista);
                return doboz;
            }
        }
    }
}
