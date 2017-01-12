using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CurrencyConverter.Domain;
using CurrencyConverter.BL;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CurrencyCalculatorService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CurrencyCalculatorService.svc or CurrencyCalculatorService.svc.cs at the Solution Explorer and start debugging.
    public class CurrencyCalculatorService : ICurrencyCalculatorService
    {
        public CurrencyData GetBySymbol(string symbolCode)
        {
            return BLFactory.GetCalculator().GetCurrencyData(symbolCode);
        }
    }
}
