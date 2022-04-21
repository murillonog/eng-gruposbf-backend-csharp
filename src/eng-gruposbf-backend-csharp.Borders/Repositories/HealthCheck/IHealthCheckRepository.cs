using System.Threading.Tasks;

namespace eng_gruposbf_backend_csharp.Borders.Repositories.HealthCheck
{
    public interface IHealthCheckRepository
    {
        Task<string> Ping(string url);
    }
}
