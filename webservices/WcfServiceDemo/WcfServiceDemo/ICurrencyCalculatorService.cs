using CurrencyConverter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceDemo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICurrencyCalculatorService" in both code and config file together.
    [ServiceContract]
    public interface ICurrencyCalculatorService
    {
        [OperationContract]
        string GetCurrencyData(string symbol);
    }
}
