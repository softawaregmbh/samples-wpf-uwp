using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CurrencyConverter.Domain;
using CurrencyConverter.BL;

namespace WcfServiceDemo
{
    public class CurrencyCalculatorService : ICurrencyCalculatorService
    {
        public string GetCurrencyData(string symbol)
        {
            return symbol; //BLFactory.GetCalculator().GetCurrencyData(symbol);
        }
    }
}
