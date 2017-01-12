using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyCalculator.BL
{
    public class CurrencyCalculatorProxy : ICurrencyCalculator
    {
        private ICurrencyCalculator inMemoryCurrencyCalculator;
        private string baseUrl;


        public CurrencyCalculatorProxy(string baseUrl, ICurrencyCalculator inMemoryCurrencyCalculator)
        {
            this.baseUrl = baseUrl;
            this.inMemoryCurrencyCalculator = inMemoryCurrencyCalculator;
        }

        public double Convert(double value, string sourceCurrency, string targetCurrency)
        {
            return this.inMemoryCurrencyCalculator.Convert(value, sourceCurrency, targetCurrency);
        }

        public async Task<IEnumerable<CurrencyData>> GetCurrencyData()
        {
            using (var client = new HttpClient())
            {
                string json = await client.GetStringAsync(baseUrl + "/currencies/top/100");

                return JsonConvert.DeserializeObject<IEnumerable<CurrencyData>>(json);
            }
        }

        public IEnumerable<RangeCurrencyData> MonthlyRatesOfExchange(string sourceCurrency, string targetCurrency, DateTime from, DateTime to)
        {
            return this.inMemoryCurrencyCalculator.MonthlyRatesOfExchange(sourceCurrency, targetCurrency, from, to);
        }

        public double RateOfExchange(string sourceCurrency, string targetCurrency)
        {
            return this.inMemoryCurrencyCalculator.RateOfExchange(sourceCurrency, targetCurrency);
        }
    }
}
