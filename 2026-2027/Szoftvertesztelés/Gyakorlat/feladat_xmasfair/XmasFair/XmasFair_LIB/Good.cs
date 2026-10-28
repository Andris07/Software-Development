using System;
using System.Collections.Generic;
using System.Text;

namespace XmasFair_LIB
{
    public class Good
    {
        public string Name { get; init; }
        public string Type { get; init; }
        public int Value { get; init; }

        public Good(string name, string type, int value)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException();
            if (string.IsNullOrWhiteSpace(type)) throw new ArgumentException();

            Name = name;
            Type = type;
            Value = Math.Max(0, value);
        }
    }
}
