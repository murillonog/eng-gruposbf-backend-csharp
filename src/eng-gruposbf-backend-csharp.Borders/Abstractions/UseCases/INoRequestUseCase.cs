using System.Threading.Tasks;

namespace eng_gruposbf_backend_csharp.Borders.Abstractions.UseCases
{
    public interface INoRequestUseCase<TResponse>
    {
        Task<UseCaseResponse<TResponse>> Execute();
    }
}
