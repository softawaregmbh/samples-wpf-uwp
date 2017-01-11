using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.BL
{
    public class BLFactory
    {

        private static ICurrencyCalculator calc;

        public static ICurrencyCalculator GetCalculator()
        {
            if (calc == null)
            {
                calc = new CurrencyCalculator();
            }

            return calc;
        }
    }
}
