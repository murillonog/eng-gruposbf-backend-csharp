using eng_gruposbf_backend_csharp.Api.Factories;
using eng_gruposbf_backend_csharp.Borders.Dtos.Currency;
using eng_gruposbf_backend_csharp.Borders.UseCases.ListCoins;
using eng_gruposbf_backend_csharp.Borders.UseCases.PriceConverter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eng_gruposbf_backend_csharp.Api.Controllers
{
    [Route("api/price-converter")]
    public class PriceConverterController : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CurrencyResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CurrencyResponse))]
        public async Task<IActionResult> Get(
            [FromServices] IActionResultFactory actionResultFactory,
            [FromServices] IPriceConverterUseCase priceConverterUseCase,
            [FromQuery] CurrencyRequest currencyRequest)
        {
            var response = await priceConverterUseCase.Execute(currencyRequest);
            return actionResultFactory.Build(response);
        }        
    }
}
