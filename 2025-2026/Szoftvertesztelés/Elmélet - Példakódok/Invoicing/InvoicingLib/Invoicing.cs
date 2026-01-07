namespace InvoicingLib;

public class Invoicing
{
    private struct Item
    {
        public string Description;
        public int Price;
    }

    public int NetTotal => _items.Sum(item => item.Price);

    public int TotalVat
    {
        get
        {
            double result = 0;
            foreach (var item in _items)
            {
                double key = 0.27;
                if (item.Description == "Csirkefarhát")
                {
                    key = 0.05;
                }
                result += item.Price * key;
            }

            return (int)Math.Round(result);
        }
    }

    public int Total => NetTotal + TotalVat;

    private List<Item> _items = new();

    public void Add(string description, int amount)
    {
        _items.Add(new Item()
        {
            Description = description,
            Price = amount
        });
    }

    public string Print()
    {
        string result = "\n\n\t\tNYUGTA\n";
        foreach (var item in _items)
        {
            result += $"\t{item.Description}\t{item.Price}\n";
        }

        result += "===================\n";
        result += $"VÉGÖSSZEG:\t{Total}\n";
        result += $"ÁFA:\t\t{TotalVat}\n";

        return result;
    }
}