using CurrencyCore;
using CurrencyCore.DTOs;
using CurrencyCore.Services;
using CurrencyEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrencyAPI.Controllers
{
    [Route("api/converter")]
    [ApiController]
    public class CurrencyConverterController : ControllerBase
    {
        private readonly ICurrencyConverterService _currencyConverterService;
        private readonly ILogger<CurrencyConverterController> _logger;

        public CurrencyConverterController(ICurrencyConverterService currencyConverterService, ILogger<CurrencyConverterController> logger)
        {
            _currencyConverterService = currencyConverterService;
            _logger = logger;
        }

        /// <summary>
        /// Convert one currency to another.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<ActionResult<CurrencyValueDto>> ConvertCurrency([FromQuery] CurrencyConverterParams currencyConverterParams)
        {
            _logger.LogWarning("Converting currency.");
            return await _currencyConverterService.ConvertCurrency(currencyConverterParams); 
        }
    }
}
