using eng_gruposbf_backend_csharp.Borders.Dtos.Bacen;
using eng_gruposbf_backend_csharp.Borders.Repositories.BacenConverter;
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
    public class BacenConverterRepository : HttpRepository, IBacenConverterRepository
    {
        private readonly ApiGateway _apiGateway;

        public BacenConverterRepository(
            IHttpClientFactory httpClientFactory,
            ILogger<HttpRepository> logger,
            IOptions<ApiGateway> options) : base(httpClientFactory.CreateClient(Shared.Constants.BCBService), logger, options.Value)
        {
            _apiGateway = options.Value;
        }
        public async Task<BacenQuotation> Get(string name, string date)
        {
            var resource = _apiGateway
                .GetResource(Shared.Constants.BCBService)
                .GetParameter("CotacaoMoedaDia")
                .Value;
            try
            {
                var result = await GetAsStringAsync($"{resource}@moeda='{name}'&@dataCotacao='{date}'");

                return JsonConvert.DeserializeObject<BacenQuotation>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error to converter currency: {ex.Message}");
            }
        }
    }
}
