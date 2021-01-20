using CurrencyEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExternalAPIConsumer
{
    public interface IAPIConsumer
    {
        Task<CurrencyExternal> GetExchangeRatesForCurrency(string code);

    }
}
