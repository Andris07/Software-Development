namespace XmasFair_LIB
{
    public class Fair
    {
        public string Name { get; init; }
        public int StandCount { get; init; }
        public int StandPrice { get; init; }
        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }

        public Fair(string name, int standCount, int standPrice, string startDate, string endDate)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException();
            if (standCount < 0) throw new ArgumentException();
            if (standPrice < 0) throw new ArgumentException();
            if (DateOnly.Parse(endDate) < DateOnly.Parse(startDate)) throw new ArgumentException();

            Name = name;
            StandCount = standCount;
            StandPrice = standPrice;
            StartDate = DateOnly.Parse(startDate);
            EndDate = DateOnly.Parse(endDate);
        }

        readonly List<Stand> stands = new List<Stand>();
        public int FreePlace => StandCount - stands.Count;
        public int Income => stands.Count * StandPrice;

        public bool AddStand(Stand stand)
        {
            if (stand == null) return false;
            if (stands.Count >= StandCount) return false;
            if (stands.Any(x => x.Name == stand.Name)) return false;

            stands.Add(stand);
            return true;
        }

        public bool RemoveStand(string name)
        {
            Stand stand = stands.FirstOrDefault(x => x.Name == name)!;

            if (stand == null) return false;

            stands.Remove(stand);
            return true;
        }
    }
}
