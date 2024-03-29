﻿using eng_gruposbf_backend_csharp.Api.Factories;
using eng_gruposbf_backend_csharp.Borders.UseCases.ListCoins;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eng_gruposbf_backend_csharp.Api.Controllers
{
    [Route("api/coins")]
    [Produces("application/json")]
    public class CoinController : Controller
    {
        /// <summary>
        /// Returns the list of all convertible currencies.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(IEnumerable<string>))]
        public async Task<IActionResult> GetCoins(
            [FromServices] IActionResultFactory actionResultFactory,
            [FromServices] IListCoinsUseCase listCoinsUseCase)
        {
            var response = await listCoinsUseCase.Execute();
            return actionResultFactory.Build(response);
        }
    }
}
