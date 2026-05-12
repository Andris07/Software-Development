using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NyelviskolaLIB
{
    public class TanitasiAlkalom
    {
        // alkalom_id;tanar_id;datum;kezdesido;orak_szama
        public int AlkalomID { get; init; }
        public int TanarID { get; init; }

        [JsonIgnore]
        public DateTime Datum { get; init; }
        [JsonPropertyName("datum")]
        public string DatumFormatum => Datum.ToString("yyyy-MM-dd");

        [JsonIgnore]
        public TimeSpan KezdesIdo { get; init; }
        [JsonPropertyName("kezdesIdo")]
        public string KezdesIdoFormatum => Datum.Add(KezdesIdo).ToString("HH:mm:ss");

        public int OrakSzama { get; init; }

        static DateTime ParseDate(string str)
        {
            var split = str.Split(".");
            return new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
        }

        static TimeSpan ParseTime(string str)
        {
            var split = str.Split(":");
            return new TimeSpan(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
        }

        public TanitasiAlkalom(string adatSor)
        {
            string[] adatReszek = adatSor.Split(";");
            this.AlkalomID = int.Parse(adatReszek[0]);
            this.TanarID = int.Parse(adatReszek[1]);
            this.Datum = ParseDate(adatReszek[2]);
            this.KezdesIdo = ParseTime(adatReszek[3]);
            this.OrakSzama = int.Parse(adatReszek[4]);
        }

        [JsonIgnore]
        public int Dij => OrakSzama * DataStore.Instance?.Tanarok?.FirstOrDefault(x => x.TanarID == TanarID)?.Oradij ?? 0;

        public bool AdottHonapbanVanE(int ev, int honap)
        {
            return Datum.Year == ev && Datum.Month == honap;
        }
    }
}
