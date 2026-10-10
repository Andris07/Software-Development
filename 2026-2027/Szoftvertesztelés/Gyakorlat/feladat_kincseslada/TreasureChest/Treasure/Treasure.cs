namespace Treasure
{
    public class Treasure
    {
        public string Name { get; init; }
        private int _volume;

        public int Volume
        {
            get => _volume;

            init
            {
                if (value <= 0) throw new VolumeException();
                _volume = value;
            }
        }

        public Treasure(string name, int volume)
        {
            Name = name;
            Volume = volume;
        }
    }
}
