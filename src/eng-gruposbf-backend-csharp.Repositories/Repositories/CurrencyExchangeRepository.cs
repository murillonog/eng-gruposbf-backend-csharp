using eng_gruposbf_backend_csharp.Borders.Repositories.CurrencyExchange;
using eng_gruposbf_backend_csharp.Shared.Extensions;
using eng_gruposbf_backend_csharp.Shared.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace eng_gruposbf_backend_csharp.Repositories.Repositories
{
    public class CurrencyExchangeRepository : HttpRepository, ICurrencyExchangeRepository
    {
        private readonly ApiGateway _apiGateway;

        public CurrencyExchangeRepository(
            IHttpClientFactory httpClientFactory,
            ILogger<HttpRepository> logger,
            IOptions<ApiGateway> options) : base(httpClientFactory.CreateClient(Shared.Constants.CurrencyService), logger, options.Value)
        {
            _apiGateway = options.Value;
        }

        public async Task<decimal> Get(string name)
        {
            var resource = _apiGateway
                .GetResource(Shared.Constants.CurrencyService)
                .GetParameter("Exchange")
                .Value;
            try
            {
                var result = await GetAsStringAsync($"{resource}from=BRL&to={name}&q=1.0");

                return JsonConvert.DeserializeObject<decimal>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error to converter currency: {ex.Message}");
            }
        }
    }
}
