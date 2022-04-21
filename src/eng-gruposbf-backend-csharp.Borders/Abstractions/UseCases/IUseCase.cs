using System.Threading.Tasks;

namespace eng_gruposbf_backend_csharp.Borders.Abstractions.UseCases
{
    public interface IUseCase<in TRequest, TResponse>
    {
        Task<UseCaseResponse<TResponse>> Execute(TRequest request);
    }
}
