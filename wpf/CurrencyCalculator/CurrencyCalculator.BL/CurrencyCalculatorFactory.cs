namespace CurrencyCalculator.BL
{
    public class CurrencyCalculatorFactory
    {
        private static ICurrencyCalculator calculator;

        public static ICurrencyCalculator GetCalculator()
        {
            //if (calculator == null)
            //    calculator = new CurrencyCalculatorService();

            if (calculator == null)
                calculator = new CurrencyCalculatorProxy("http://localhost:17955",
                    new CurrencyCalculatorService());

            return calculator;
        }
    }
}
