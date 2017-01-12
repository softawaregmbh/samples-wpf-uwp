using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSwagger();

            Console.ReadKey();
        }

        private static async Task TestSwagger()
        {
            using (var proxy = new WebApiSample(new Uri("http://localhost:17955/")))
            {
                var data = await proxy.Currencies.GetBySymbolAsync("EUR");

                var response = await proxy.Currencies.GetBySymbolWithOperationResponseAsync("EUR");

                var headers = response.Response.Headers;

            }
        }
    }
}
