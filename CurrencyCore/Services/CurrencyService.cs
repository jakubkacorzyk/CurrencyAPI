using AutoMapper;
using CurrencyCore.DTOs;
using CurrencyDAL;
using CurrencyEntities;
using ExternalAPIConsumer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyCore.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly CurrencyDBContext _dBContext;
        private readonly IMapper _mapper;
        private readonly IAPIConsumer _APIConsumer;
        private readonly ILogger<CurrencyService> _logger;
        public CurrencyService(CurrencyDBContext dBContext, IMapper mapper, IAPIConsumer APIConsumer, ILogger<CurrencyService> logger)
        {
            _dBContext = dBContext;
            _mapper = mapper;
            _APIConsumer = APIConsumer;
            _logger = logger;
        }

        public async Task<IEnumerable<CurrencyDto>> GetCurrenciesAsync()
        {
            _logger.LogInformation("GET - list of currencies");
            return _mapper.Map<IEnumerable<CurrencyDto>>(await _dBContext.Currencies.ToListAsync());
        }

        public async Task<CurrencyExternal> GetCurrency(string code)
        {
            _logger.LogInformation("GET - currency details");
            if (await _dBContext.Currencies.FirstOrDefaultAsync(x => x.Code.Equals(code.ToUpper())) == null){
                throw new Exception($"Currency with code {code} does not exists in database!");
            }

            return await _APIConsumer.GetExchangeRatesForCurrency(code);
        }
    }
}
