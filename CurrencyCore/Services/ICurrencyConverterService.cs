using CurrencyCore.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyCore.Services
{
    public interface ICurrencyConverterService
    {
        Task<CurrencyValueDto> ConvertCurrency(CurrencyConverterParams currencyConverterParams);
    }
}
