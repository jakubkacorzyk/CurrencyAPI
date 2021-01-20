using CurrencyEntities;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExternalAPIConsumer
{
    public class APIConsumer : IAPIConsumer
    {
        private readonly string apiUrl = "http://api.nbp.pl/api";
        private RestClient _restClient;
        private readonly ILogger<APIConsumer> _logger;
        public APIConsumer(ILogger<APIConsumer> logger)
        {
            _restClient = new RestClient(apiUrl);
            _logger = logger;
        }

        public async Task<CurrencyExternal> GetExchangeRatesForCurrency(string code)
        {
            _logger.LogInformation("EXTERNAL API - GET - exchange rate for currency");
            var request = new RestRequest("/exchangerates/rates/a/" + code + "/", DataFormat.Json);
            return await _restClient.GetAsync<CurrencyExternal>(request);
        }
    }
}
