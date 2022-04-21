using eng_gruposbf_backend_csharp.Borders.Abstractions.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace eng_gruposbf_backend_csharp.Api.Factories
{
    public class ActionResultFactory : IActionResultFactory
    {
        private readonly string _path;
        private readonly ILogger<ActionResultFactory> _logger;

        public ActionResultFactory(IHttpContextAccessor accessor, ILogger<ActionResultFactory> logger)
        {
            _logger = logger;
            _path = accessor.HttpContext.Request.Path.Value;
        }

        public IActionResult Build<T>(UseCaseResponse<T> response)
        {
            if (response == null)
            {
                return BuildError(ErrorMessage.NullResponse(nameof(ActionResultFactory)),
                    UseCaseResponseStatus.InternalServerError);
            }

            if (response.HasErrors())
            {
                return BuildError(response.Errors ?? ErrorMessage.Unknown(), UseCaseResponseStatus.InternalServerError);
            }

            return new OkObjectResult(response.Content);
        }

        private ObjectResult BuildError(object data, UseCaseResponseStatus responseStatus)
        {
            if (responseStatus == UseCaseResponseStatus.InternalServerError)
                Log.Error("[ERROR] {Path} ({Data})", _path, data);

            return new ObjectResult(data)
            {
                StatusCode = (int)responseStatus
            };
        }
    }
}
