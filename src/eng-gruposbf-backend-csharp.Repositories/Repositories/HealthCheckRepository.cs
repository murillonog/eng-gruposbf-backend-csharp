using eng_gruposbf_backend_csharp.Borders.Repositories.HealthCheck;
using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace eng_gruposbf_backend_csharp.Repositories.Repositories
{
    public class HealthCheckRepository : IHealthCheckRepository
    {
        public async Task<string> Ping(string url)
        {
            try
            {
                var ping = new Ping();
                var result = await ping.SendPingAsync(url);
                return result.Status.ToString();
            }
            catch (Exception ex)
            {
                throw new PingException($"Ping request fail to {url}", ex);
            }
        }
    }
}
