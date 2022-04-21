using eng_gruposbf_backend_csharp.Borders.Abstractions.UseCases;
using eng_gruposbf_backend_csharp.Borders.Dtos.HealthCheck;

namespace eng_gruposbf_backend_csharp.Borders.UseCases.HealthCheck
{
    public interface IHealthCheckUseCase : INoRequestUseCase<HealthCheckResponse> { }
}
