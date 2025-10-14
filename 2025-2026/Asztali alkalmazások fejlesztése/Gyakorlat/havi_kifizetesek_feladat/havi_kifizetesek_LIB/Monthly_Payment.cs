namespace havi_kifizetesek_LIB
{
    public class Monthly_Payment
    {
        public string Name { get; init; }
        public int Payment { get; init; }

        public Monthly_Payment(string name, int payment)
        {
            this.Name = name;
            this.Payment = payment;
        }
    }
}
