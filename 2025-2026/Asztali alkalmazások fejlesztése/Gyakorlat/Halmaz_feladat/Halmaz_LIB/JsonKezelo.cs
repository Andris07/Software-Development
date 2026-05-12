using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Halmaz_LIB
{
    public static class JsonKezelo
    {
        public static void JsonMentes<Tipus>(string fajlNev, Halmaz<Tipus> adatok)
        {
            var json = JsonSerializer.Serialize(adatok.Sorozat());
            File.WriteAllText(fajlNev, json);
        }

        public static List<Tipus> JsonBetoltes<Tipus>(string fajlnev)
        {
            var json = File.ReadAllText(fajlnev);
            return JsonSerializer.Deserialize<List<Tipus>>(json)!;
        }
    }
}
