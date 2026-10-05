namespace Teasdobozok_LIB
{
    public class Filter
    {
        // ID;Tipus;Ar
        public string ID { get; init; }
        public string Tipus { get; init; }
        public int Ar { get; init; }

        public Filter(string id, string tipus, int ar)
        {
            this.ID = id;
            this.Tipus = tipus;
            this.Ar = ar;
        }

        public bool Gyogytea => ID.ToLower().StartsWith("z");

        public override string ToString()
        {
            return $"{Tipus} ({Ar} Ft)";
        }
    }
}
