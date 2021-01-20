using CurrencyCore.DTOs;
using ExternalAPIConsumer;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyCore.Services
{
    public class CurrencyConverterService : ICurrencyConverterService
    {
        private readonly IAPIConsumer _APIConsumer;
        private readonly ILogger<CurrencyConverterService> _logger;

        public CurrencyConverterService(IAPIConsumer aPIConsumer, ILogger<CurrencyConverterService> logger)
        {
            _APIConsumer = aPIConsumer;
            _logger = logger;
        }

        public async Task<CurrencyValueDto> ConvertCurrency(CurrencyConverterParams currencyConverterParams)
        {
            _logger.LogInformation("GET - convert parameters");
            var fromCurrency = await _APIConsumer.GetExchangeRatesForCurrency(currencyConverterParams.CodeFrom);
            var toCurrency = await _APIConsumer.GetExchangeRatesForCurrency(currencyConverterParams.CodeTo);

            var convertedValue = Convert(fromCurrency.Rates[0].Mid, toCurrency.Rates[0].Mid, currencyConverterParams.Value);

            return new CurrencyValueDto(toCurrency.Currency, toCurrency.Code, toCurrency.Rates[0].Mid, convertedValue);
        }

        private double Convert(double from, double to, double value)
        {
            return Math.Round(value * from / to, 4);
        }
    }
}
