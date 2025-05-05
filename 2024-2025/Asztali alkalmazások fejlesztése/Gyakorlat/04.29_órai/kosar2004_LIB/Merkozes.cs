namespace kosar2004_LIB
{
    public class Merkozes
    {
        public Merkozes(string adatSor)
        {
            string[] adatReszek = adatSor.Split(";");
            Hazai = adatReszek[0];
            Idegen = adatReszek[1];
            Hazai_pont = int.Parse(adatReszek[2]);
            Idegen_pont = int.Parse(adatReszek[3]);
            Helyszin = adatReszek[4];
            Idopont = DateOnly.Parse(adatReszek[5]);
        }

        //hazai; idegen; hazai_pont; idegen_pont; helyszín; időpont

        public string Hazai { get; init; }
        public string Idegen { get; init; }
        public int Hazai_pont { get; init; }
        public int Idegen_pont { get; init; }
        public string Helyszin { get; init; }
        public DateOnly Idopont { get; init; }
        public bool Dontetlen => Hazai_pont == Idegen_pont;
        public bool SzazPontnalTobbHazai => Hazai_pont > 100;
        public int PontKulonbseg => Math.Abs(Hazai_pont - Idegen_pont);

        public override string ToString()
        {
            return $"{Idopont}: {Hazai} - {Idegen} ({Hazai_pont}:{Idegen_pont})";
        }
    }
}
