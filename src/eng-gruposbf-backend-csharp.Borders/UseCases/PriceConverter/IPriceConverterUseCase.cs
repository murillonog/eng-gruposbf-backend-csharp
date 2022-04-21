using eng_gruposbf_backend_csharp.Borders.Abstractions.UseCases;
using eng_gruposbf_backend_csharp.Borders.Dtos.Currency;

namespace eng_gruposbf_backend_csharp.Borders.UseCases.PriceConverter
{
    public interface IPriceConverterUseCase : IUseCase<CurrencyRequest, CurrencyResponse> { }
}
