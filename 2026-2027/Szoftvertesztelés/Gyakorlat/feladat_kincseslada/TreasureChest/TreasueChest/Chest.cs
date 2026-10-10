using Treasure;

namespace TreasureChest
{
    public class Chest
    {
        public string Name { get; init; }
        public bool IsLocked;
        public bool IsOpen;
        private List<Treasure.Treasure> _contents;
        private int _volume;

        public int Volume
        {
            get => _volume;

            init
            {
                if (value < 0) throw new VolumeException();
                _volume = value;
            }
        }

        public Chest(string name, int volume)
        { 
            Volume = volume;
            Name = name;
            IsLocked = true;
            IsOpen = false;
            _contents = new();
        }

        public bool Open()
        {
            if (!IsLocked && !IsOpen)
            {
                IsOpen = true;
                return IsOpen;
            }
            return false;
        }

        public bool Close()
        {
            if (!IsLocked && IsOpen)
            {
                IsOpen = false;
                return !IsOpen;
            }
            return false;
        }

        public bool Lock()
        {
            if (!IsLocked && !IsOpen)
            {
                IsLocked = true;
                return IsLocked;
            }
            return false;
        }

        public bool UnLock()
        {
            if (IsLocked && !IsOpen)
            {
                IsLocked = false;
                return !IsLocked;
            }
            return false;
        }

        private int FreeSpace => Volume - _contents.Sum(x => x.Volume);

        public bool Store(Treasure.Treasure treasure)
        {
            if (treasure.Volume > FreeSpace || !IsOpen) return false;
            _contents.Add(treasure);
            return true;
        }

        public override string ToString()
        {
            string description = $"{Name} térfogat: {Volume} ebből szabad: {FreeSpace} ";

            if (_contents.Count == 0) description += "Nincs benne semmi.";
            
            else
            {
                description += "Tartalma: " + string.Join(", ", _contents.Select(x => x.Name));
            }
            return description;
        }

        public Treasure.Treasure? TakeOutLast()
        {
            if (_contents.Count == 0 || !IsOpen) return null;
            Treasure.Treasure lastTreasure = _contents.Last<Treasure.Treasure>();
            _contents.RemoveAt(_contents.Count - 1);
            return lastTreasure;
        }

        public Treasure.Treasure? TakeOut(string name)
        {
            if (_contents.Count == 0 || !IsOpen) return null;
            Treasure.Treasure? treasure = null;
            
            int i = 0;
            while (i < _contents.Count)
            {
                if (_contents[i].Name == name)
                {
                    treasure = _contents[i];
                    _contents.RemoveAt(i);
                    break;
                }
                i++;
            }
            return treasure;
        }
    }
}