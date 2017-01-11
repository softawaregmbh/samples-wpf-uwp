using CurrencyConverter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.BL
{

    public interface ICurrencyCalculator
    {
        double RateOfExchange(string srcCurr, string targCurr);
        CurrencyData GetCurrencyData(string currSymbol);
        IEnumerable<string> GetCurrencies();
        bool CurrencyExists(string currSymbol);
        void Insert(CurrencyData data);
        void Update(CurrencyData data);
    }
}
