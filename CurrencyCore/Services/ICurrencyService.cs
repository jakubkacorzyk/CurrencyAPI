using CurrencyCore.DTOs;
using CurrencyEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyCore.Services
{
    public interface ICurrencyService
    {
        Task<IEnumerable<CurrencyDto>> GetCurrenciesAsync();
        Task<CurrencyExternal> GetCurrency(string code);
    }
}
