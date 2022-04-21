using eng_gruposbf_backend_csharp.Borders.Dtos.Bacen;
using System.Threading.Tasks;

namespace eng_gruposbf_backend_csharp.Borders.Repositories.BacenConverter
{
    public interface IBacenConverterRepository
    {
        Task<BacenQuotation> Get(string name, string date);
    }
}
