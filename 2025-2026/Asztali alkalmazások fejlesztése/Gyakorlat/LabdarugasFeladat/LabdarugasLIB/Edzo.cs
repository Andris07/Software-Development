namespace LabdarugasLIB
{
    public class Edzo
    {
        // EdzoID;Nev;Csapat;Trofeak;BonuszPerTrofea;EvekSzama;EvesFizetes
        public int EdzoID { get; init; }
        public string Nev { get; init; }
        public string Csapat { get; init; }
        public int Trofeak { get; init; }
        public int BonuszPerTrofea { get; init; }
        public int EvekSzama { get; init; }
        public int EvesFizetes { get; init; }

        public Edzo(string fájlSor)
        {
            string[] adatok = fájlSor.Split(";");
            this.EdzoID = int.Parse(adatok[0]);
            this.Nev = adatok[1];
            this.Csapat = adatok[2];
            this.Trofeak = int.Parse(adatok[3]);
            this.BonuszPerTrofea = int.Parse(adatok[4]);
            this.EvekSzama = int.Parse(adatok[5]);
            this.EvesFizetes = int.Parse(adatok[6]);
        }
        
        // Számított tulajdonságok
        public int BevetelTrofeakbol => Trofeak * BonuszPerTrofea;
        public int BevetelFizetesbol => EvesFizetes * EvekSzama;
        public int OsszBevetel => BevetelTrofeakbol + BevetelFizetesbol;

        public override string ToString()
        {
            return $"{Nev} jelenleg a {Csapat} edzője, melyet sikeres pályafutásának köszönhet, ugyanis karrierje során összesen {Trofeak} tróféát nyert. {EvekSzama} éve van a csapatnál.";
        }
    }
}
