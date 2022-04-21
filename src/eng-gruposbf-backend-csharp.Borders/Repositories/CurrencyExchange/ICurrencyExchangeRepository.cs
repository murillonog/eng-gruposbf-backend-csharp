using System.Threading.Tasks;

namespace eng_gruposbf_backend_csharp.Borders.Repositories.CurrencyExchange
{
    public interface ICurrencyExchangeRepository
    {
        Task<decimal> Get(string name);  
    }
}
