namespace CurrencyCalculator.BL
{
    public class CurrencyCalculatorFactory
    {
        private static ICurrencyCalculator calculator;

        public static ICurrencyCalculator GetCalculator()
        {
            if (calculator == null)
                calculator = new CurrencyCalculatorService();
            return calculator;
        }
    }
}
