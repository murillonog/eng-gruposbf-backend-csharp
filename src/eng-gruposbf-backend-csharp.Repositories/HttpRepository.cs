using eng_gruposbf_backend_csharp.Borders.Exceptions;
using eng_gruposbf_backend_csharp.Shared.Settings;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace eng_gruposbf_backend_csharp.Repositories
{
    public abstract class HttpRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HttpRepository> _logger;
        private readonly ApiGateway _apiGateway;

        protected HttpRepository(HttpClient httpClient, ILogger<HttpRepository> logger, ApiGateway apiGateway)
        {
            _httpClient = httpClient;
            _logger = logger;
            _apiGateway = apiGateway;
        }

        private static async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) return;

            if (response.Content == null)
            {
                throw new BusinessException(response.StatusCode);
            }

            var content = await response.Content.ReadAsStringAsync();
            response.Content?.Dispose();

            throw new BusinessException(response.StatusCode, content);
        }

        protected async Task<string> GetAsStringAsync(string resource)
        {
            var response = await _httpClient.GetAsync(resource);
            await EnsureSuccessStatusCodeAsync(response);

            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<T> GetAsGenerics<T>(string resource)
        {
            var response = await _httpClient.GetAsync(resource);
            await EnsureSuccessStatusCodeAsync(response);

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString);
        }

        protected async Task<byte[]> GetAsByteArrayAsync(string resource)
        {
            var response = await _httpClient.GetAsync(resource);
            await EnsureSuccessStatusCodeAsync(response);

            return await response.Content.ReadAsByteArrayAsync();
        }

    }
}
