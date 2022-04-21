using System.Collections.Generic;
using System.Linq;

namespace eng_gruposbf_backend_csharp.Borders.Dtos.Currency
{
    public class CurrencyResponse
    {
        public List<CurrencyDto> Currencies { get; }

        public CurrencyResponse(IEnumerable<CurrencyDto> currencies)
        {
            Currencies = currencies.ToList();
        }

        public CurrencyResponse() : this(new List<CurrencyDto>()) { }
    }
}
