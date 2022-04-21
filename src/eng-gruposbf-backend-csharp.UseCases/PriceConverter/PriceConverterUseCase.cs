using eng_gruposbf_backend_csharp.Borders.Abstractions.UseCases;
using eng_gruposbf_backend_csharp.Borders.Dtos.Currency;
using eng_gruposbf_backend_csharp.Borders.Dtos.Enums;
using eng_gruposbf_backend_csharp.Borders.Extensions;
using eng_gruposbf_backend_csharp.Borders.Repositories.BacenConverter;
using eng_gruposbf_backend_csharp.Borders.Repositories.CurrencyExchange;
using eng_gruposbf_backend_csharp.Borders.UseCases.PriceConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eng_gruposbf_backend_csharp.UseCases.PriceConverter
{
    public class PriceConverterUseCase : IPriceConverterUseCase
    {
        private readonly IBacenConverterRepository _bacenConverterRepository;
        private readonly ICurrencyExchangeRepository _currencyExchangeRepository;

        public PriceConverterUseCase(
            IBacenConverterRepository bacenConverterRepository, 
            ICurrencyExchangeRepository currencyExchangeRepository)
        {
            _bacenConverterRepository = bacenConverterRepository;
            _currencyExchangeRepository = currencyExchangeRepository;
        }

        public async Task<UseCaseResponse<CurrencyResponse>> Execute(CurrencyRequest request)
        {
            var response = new UseCaseResponse<CurrencyResponse>();
            var list = new List<CurrencyDto>();
            var date = DateTime.Now.TodayIsUtil();

            try
            {
                var tasks = Enum.GetNames(typeof(Coins)).ToList().Select(async name =>
                {
                    var currency = await _bacenConverterRepository.Get(name, date);
                    if (currency.Value.Any())
                    {
                        var value = Math.Round(request.Value / currency.GetLastValue(), 2);
                        return new CurrencyDto(name, value);
                    }

                    var quotation = await _currencyExchangeRepository.Get(name) * request.Value;
                    return new CurrencyDto(name, Math.Round(quotation,2));
                });

                var currencies = await Task.WhenAll(tasks);
                return response.Ok(new CurrencyResponse(currencies));
            }
            catch (Exception exception)
            {
                return response.InternalServerError(exception);
            }
        }
    }
}
