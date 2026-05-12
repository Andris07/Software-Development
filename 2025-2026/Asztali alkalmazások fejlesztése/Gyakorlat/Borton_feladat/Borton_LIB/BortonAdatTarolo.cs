using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Borton_LIB
{
    public sealed class BortonAdatTarolo
    {
        static readonly string Mappa = "saves";

        public Bortonok Bortonok { get; set; } = new();

        public void Mentes(string fajlNev = "borton.json")
        {
            Directory.CreateDirectory(Mappa);

            string teljesUtvonal = Path.Combine(Mappa, fajlNev);

            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            });

            File.WriteAllText(teljesUtvonal, json);
        }

        public static BortonAdatTarolo Betoltes(string fajlNev = "borton.json")
        {
            string teljesUtvonal = Path.Combine(Mappa, fajlNev);

            if (!File.Exists(teljesUtvonal))
                throw new FileNotFoundException("Mentett fájl nem található!");

            var json = File.ReadAllText(teljesUtvonal);
            var adat = JsonSerializer.Deserialize<BortonAdatTarolo>(json);

            adat!.ReferenciakHelyreallitasa();
            return adat;
        }

        void ReferenciakHelyreallitasa()
        {
            foreach (var borton in Bortonok.BortonokLista)
            {
                borton.Tulajdonos.Borton = borton;

                foreach (var or in borton.Orok)
                    or.Borton = borton;

                foreach (var rab in borton.Rabok)
                    rab.Borton = borton;

                foreach (var cella in borton.Cellak.Lista)
                {
                    foreach (var rab in cella.Rabok)
                    {
                        rab.Cella = cella;
                        rab.Borton = borton;

                        // FONTOS: ha a cellában van rab, de a börtön Rabok listájában nincs, pótoljuk
                        if (!borton.Rabok.Contains(rab))
                            borton.Rabok.Add(rab);
                    }
                }
            }
        }
    }
}