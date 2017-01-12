using CurrencyConverter.BL;
using CurrencyConverter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiSample.Controllers
{
    public class CurrenciesController : ApiController
    {
        private ICurrencyCalculator calculator = BLFactory.GetCalculator();

        /// <summary>
        /// Gets currency data by its currency symbol, e.g. EUR.
        /// </summary>
        /// <param name="symbol">Currency symbol in upper case</param>
        /// <returns>A currency data object with information about the currency</returns>
        [HttpGet]
        [Route("currencies/{symbol}", Name = "GetBySymbolRoute")]
        public CurrencyData GetBySymbol(string symbol)
        {
            if (!calculator.CurrencyExists(symbol))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return calculator.GetCurrencyData(symbol);
        }

        [HttpGet]
        [Route("currencies/top/{amount}")]
        public IEnumerable<CurrencyData> GetAll(int amount = 10)
        {
            var currencyCodes = calculator.GetCurrencies();
            return currencyCodes.Select(c => calculator.GetCurrencyData(c)).Take(amount).ToList();
        }

        [HttpPost]
        [Route("currencies/search")]
        public IEnumerable<CurrencyData> Search([FromBody]CurrencyQuery query)
        {
            var currencyCodes = calculator.GetCurrencies();
            var all = currencyCodes.Select(c => calculator.GetCurrencyData(c));

            if (!string.IsNullOrEmpty(query.Country))
            {
                all = all.Where(p => p.Country == query.Country);
            }

            return all.Take(query.MaxCount).ToList();
        }

        [HttpPut]
        [Route("currencies")]
        public void Update(CurrencyData data)
        {
            if (!calculator.CurrencyExists(data.Symbol))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            calculator.Update(data);
        }

        [HttpPost]
        [Route("currencies")]
        public HttpResponseMessage Insert(CurrencyData data)
        {
            if (calculator.CurrencyExists(data.Symbol))
            {
                return Request.CreateResponse(HttpStatusCode.Conflict);
            }

            calculator.Insert(data);

            var response = this.Request.CreateResponse(HttpStatusCode.Created);

            var url = Url.Route("GetBySymbolRoute", new { symbol = data.Symbol });
            var fullurl = this.Request.RequestUri.Scheme + "://" + this.Request.RequestUri.Host + url;
            response.Headers.Location = new Uri(url);

            return response;
        }

    }
}
