namespace kiralyok_LIB
{
    public class King
    {
        public int ID { get; init; }
        public string Name { get; init; }
        public string? NickName { get; init; }
        public int BirthDate { get; init; }
        public int DeathDate { get; init; }
        public string House { get; init; }
        public int StartOfRuling { get; init; }
        public int EndOfRuling { get; init; }
        public int? CrowningDate { get; init; }

        public King(int id, string name, string? nickName, int birthDate, int deathDate, string house, int startOfRuling, int endOfRuling, int? crowningDate)
        {
            this.ID = id;
            this.Name = name;
            this.NickName = nickName;
            this.BirthDate = birthDate;
            this.DeathDate = deathDate;
            this.House = house;
            this.StartOfRuling = startOfRuling;
            this.EndOfRuling = endOfRuling;
            this.CrowningDate = crowningDate;
        }

        public bool HasNickName() => NickName != null;
    }
}