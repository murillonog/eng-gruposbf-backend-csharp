using eng_gruposbf_backend_csharp.Api.Factories;
using eng_gruposbf_backend_csharp.Borders.Dtos.HealthCheck;
using eng_gruposbf_backend_csharp.Borders.UseCases.HealthCheck;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eng_gruposbf_backend_csharp.Api.Controllers
{
    [Route("api/healthcheck")]
    [Produces("application/json")]
    public class HealthCheckController : ControllerBase
    {
        /// <summary>
        /// Checks all connections we make.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HealthCheckResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(HealthCheckResponse))]
        public async Task<IActionResult> Get(
            [FromServices] IActionResultFactory actionResultFactory,
            [FromServices] IHealthCheckUseCase healthCheckUseCase)
        {
            var response = await healthCheckUseCase.Execute();
            return actionResultFactory.Build(response);
        }
    }
}
