namespace CurrencyCalculator.BL
{
    public class CurrencyData
    {
        public CurrencyData() { }

        public CurrencyData(string symbol, string name, string country)
        {
            this.Symbol = symbol;
            this.Name = name;
            this.Country = country;
        }

        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return this.Symbol;
        }
    }
}
