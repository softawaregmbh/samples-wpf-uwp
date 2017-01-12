using System;
using System.Collections.Generic;
using CurrencyConverter.Domain;

namespace CurrencyConverter.BL
{

    public class CurrencyCalculator : ICurrencyCalculator
    {
        private class Entry
        {

            public String Name;      // long form of currency name
            public String Country;   // country currency is used in
            public double Rate;      // current rate of exchange

            public Entry(String name, String country, double rate)
            {
                this.Name = name;
                this.Country = country;
                this.Rate = rate;
            }
        }

        // currTable maps each currency string to an Entry object
        private SortedDictionary<String, Entry> currTable =
          new SortedDictionary<string, Entry>();

        public CurrencyCalculator()
        {
            // initialize currencyTable
            currTable.Add("USD", new Entry("Dollar", "USA", 1.08783));
            currTable.Add("AUD", new Entry("Dollar", "Australia", 1.42607));
            currTable.Add("BRL", new Entry("Real", "Brazil", 3.39290));
            currTable.Add("GBP", new Entry("Pound", "GB", 0.89137));
            currTable.Add("CAD", new Entry("Dollar", "Canada", 1.45065));
            currTable.Add("CNY", new Entry("Yuan", "China", 7.37198));
            currTable.Add("DKK", new Entry("Krone", "Denmark", 7.43833));
            currTable.Add("HKD", new Entry("Dollar", "Hong Kong", 8.43739));
            currTable.Add("INR", new Entry("Rupee", "India", 72.5863));
            currTable.Add("JPY", new Entry("Yen", "Japan", 113.58));
            currTable.Add("MYR", new Entry("Ringgit", "Malysia", 4.52520));
            currTable.Add("MXN", new Entry("Peso", "Mexico", 20.1457));
            currTable.Add("EUR", new Entry("Euro", "Europe", 1.0));
        }

        private double EuroRate(String currSymbol)
        {
            Entry entry;
            if (currTable.TryGetValue(currSymbol, out entry))
                return entry.Rate;
            else
                throw new ArgumentException("invalid currency " + currSymbol);
        }


        public CurrencyData GetCurrencyData(string currSymbol)
        {
            Entry entry;
            if (currTable.TryGetValue(currSymbol, out entry))
                return new CurrencyData(currSymbol, entry.Name, entry.Country, entry.Rate);
            else
                throw new ArgumentException("invalid currency " + currSymbol);
        }

        public double RateOfExchange(string srcCurr, string targCurr)
        {
            return EuroRate(targCurr) / EuroRate(srcCurr);
        }

        public IEnumerable<string> GetCurrencies()
        {
            return currTable.Keys;
        }

        public bool CurrencyExists(string currSymbol)
        {
            return currTable.ContainsKey(currSymbol);
        }

        public void Insert(CurrencyData data)
        {
            if (currTable.ContainsKey(data.Symbol))
                throw new ArgumentException("currency " + data.Symbol + " already exists");
            currTable.Add(data.Symbol, new Entry(data.Name, data.Country, data.EuroRate));
        }

        public void Update(CurrencyData data)
        {
            Entry entry;
            if (currTable.TryGetValue(data.Symbol, out entry))
            {
                entry.Name = data.Name;
                entry.Country = data.Country;
                entry.Rate = data.EuroRate;
            }
            else
                throw new ArgumentException("invalid currency " + data.Symbol);
        }
    }

}
