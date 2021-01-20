using CurrencyCore.DTOs;
using CurrencyCore.Services;
using CurrencyEntities;
using ExternalAPIConsumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrencyAPI.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {

        private readonly ICurrencyService _currencyService;

        public CurrenciesController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        /// <summary>
        /// Get a list of possible currencies.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<CurrencyDto>>> GetCurrencies()
        {
            var result = await _currencyService.GetCurrenciesAsync();

            return Ok(result);
        }

        /// <summary>
        /// Get details of currency.
        /// </summary>
        [HttpGet("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<ActionResult<CurrencyExternal>> GetCurrency(string code)
        {
            var result = await _currencyService.GetCurrency(code);

            return Ok(result);
        }
    }
}
