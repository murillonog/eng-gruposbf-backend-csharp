using eng_gruposbf_backend_csharp.Api.Factories;
using eng_gruposbf_backend_csharp.Borders.Dtos.Currency;
using eng_gruposbf_backend_csharp.Borders.UseCases.PriceConverter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eng_gruposbf_backend_csharp.Api.Controllers
{
    [Route("api/price-converter")]
    [Produces("application/json")]
    public class PriceConverterController : Controller
    {
        /// <summary>
        /// Convert the value to different currencies.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
