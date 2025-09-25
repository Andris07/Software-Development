namespace forma1_LIB
{
    public class Forma1
    {
        public DateOnly Datum { get; init; }
        public string Helyszin { get; init; }
        public string Nev { get; init; }
        public string Nem { get; init; }
        public DateOnly? SzuletesDatum { get; init; }
        public string Nemzetiseg { get; init; }
        public int? Helyezes { get; init; }
        public string? Hiba { get; init; }
        public string? Csapat { get; init; }
        public string Tipus { get; init; }
        public string Motor { get; init; }

        public Forma1(DateOnly datum, string helyszin, string nev, string nem, DateOnly? szuletesDatum, string nemzetiseg, int? helyezes, string? hiba, string? csapat, string tipus, string motor)
        {
            this.Datum = datum;
            this.Helyszin = helyszin;
            this.Nev = nev;
            this.Nem = nem;
            this.SzuletesDatum = szuletesDatum;
            this.Nemzetiseg = nemzetiseg;
            this.Helyezes = helyezes;
            this.Hiba = hiba;
            this.Csapat = csapat;
            this.Tipus = tipus;
            this.Motor = motor;
        }
    }
}
