using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyCalculator.BL
{
    public interface ICurrencyCalculator
    {
        double RateOfExchange(string sourceCurrency, string targetCurrency);
        double Convert(double value, string sourceCurrency, string targetCurrency);
        Task<IEnumerable<CurrencyData>> GetCurrencyData();
        IEnumerable<RangeCurrencyData> MonthlyRatesOfExchange(string sourceCurrency, string targetCurrency, DateTime from, DateTime to);
    }
}
