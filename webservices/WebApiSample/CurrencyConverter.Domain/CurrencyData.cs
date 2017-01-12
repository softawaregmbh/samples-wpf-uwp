using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain
{

    [DataContract(Namespace = "http://CurrencyConverter.Domain")]
    public class CurrencyData
    {

        public CurrencyData(string symbol, string name, string country, double euroRate)
        {
            this.Symbol = symbol;
            this.Name = name;
            this.Country = country;
            this.EuroRate = euroRate;
        }

        [DataMember]
        public string Symbol { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public double EuroRate { get; set; }

        public override string ToString()
        {
            return String.Format($"{Name} ({Symbol}): euroRate={EuroRate}; country={Country}");
        }
    }
}
