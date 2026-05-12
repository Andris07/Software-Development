using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NyelviskolaLIB
{
    public class Tanar
    {
        // tanar_id;nev;nyelv_id;oradij;telefon;email;net
        public int TanarID { get; init; }
        public string Nev { get; init; }
        public int NyelvID { get; init; }
        public int Oradij { get; init; }
        public string Telefon { get; init; }
        public string Email { get; init; }

        [JsonIgnore]
        public bool Online { get; init; }
        [JsonPropertyName("online")]
        public int OnlineFormatum => Online ? 1 : 0;

        public Tanar(string adatSor)
        {
            string[] adatReszek = adatSor.Split(";");
            this.TanarID = int.Parse(adatReszek[0]);
            this.Nev = adatReszek[1];
            this.NyelvID = int.Parse (adatReszek[2]);
            this.Oradij = int.Parse(adatReszek[3]);
            this.Telefon = adatReszek[4];
            this.Email = adatReszek[5];
            this.Online = adatReszek[6] == "1";
        }

        public override string ToString()
        {
            return Nev;
        }
    }
}
