namespace WebApiSample.Controllers
{
    public class CurrencyQuery
    {
        public int MaxCount { get; set; } = 100;

        public string Country { get; set; }
    }
}