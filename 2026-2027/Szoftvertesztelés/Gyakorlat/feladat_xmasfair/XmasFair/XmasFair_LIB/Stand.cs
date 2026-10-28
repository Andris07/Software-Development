using System;
using System.Collections.Generic;
using System.Text;

namespace XmasFair_LIB
{
    public class Stand
    {
        public string Name { get; init; }
        public List<string> Types { get; init; }

        public Stand(string name, string type) : this(name, new List<string> { type })
        {

        }

        readonly List<Good> goods = new();
        int dailyIncome;
        public int NumGoods => goods.Count;
        public int DailyIncome => dailyIncome;

        public Stand(string name, List<string> types)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException();
            if (types == null || types.Count == 0 || types.Any(string.IsNullOrWhiteSpace)) throw new ArgumentException();

            Name = name;
            Types = new List<string>(types);
        }

        public void Add(Good good)
        {
            if (good == null) throw new ArgumentException();
            if (!Types.Contains(good.Type)) throw new ArgumentException();
            if (goods.Any(x => x.Name == good.Name)) throw new ArgumentException();

            goods.Add(good);
        }

        public bool Sell(string name, int quantity)
        {
            if (quantity <= 0) return false;

            Good good = goods.FirstOrDefault(x => x.Name == name)!;

            if (good == null) throw new ArgumentException();

            dailyIncome += good.Value * quantity;

            return true;
        }
    }
}