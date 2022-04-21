using eng_gruposbf_backend_csharp.Borders.Abstractions.UseCases;
using eng_gruposbf_backend_csharp.Borders.Dtos.HealthCheck;
using eng_gruposbf_backend_csharp.Borders.Repositories.HealthCheck;
using eng_gruposbf_backend_csharp.Borders.UseCases.HealthCheck;
using eng_gruposbf_backend_csharp.Shared.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eng_gruposbf_backend_csharp.UseCases.HealthCheck
{
    public class HealthCheckUseCase : IHealthCheckUseCase
    {
        readonly IHealthCheckRepository _healthCheckRepository;
        private readonly ApiGateway _apiGateway;

        public HealthCheckUseCase(
            IHealthCheckRepository healthCheckRepository, 
            IOptions<ApiGateway> options)
        {
            _healthCheckRepository = healthCheckRepository;
            _apiGateway = options.Value;
        }

        public async Task<UseCaseResponse<HealthCheckResponse>> Execute()
        {
            var response = new UseCaseResponse<HealthCheckResponse>();

            try
            {
                var tasks = _apiGateway.Resources.Select(async r =>
                {
                    var url = new Uri(r.BaseUrl);
                    var status = await _healthCheckRepository.Ping(url.Host);
                    return new HealthCheckActivity(r.Name, status);
                });

                var activities = await Task.WhenAll(tasks);
                response.Ok(new HealthCheckResponse(activities));
            }
            catch (Exception exception)
            {
                response.InternalServerError(exception);
            }

            return response;
        }
    }
}
