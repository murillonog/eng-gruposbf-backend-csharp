using eng_gruposbf_backend_csharp.Borders.Abstractions.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace eng_gruposbf_backend_csharp.Api.Factories
{
    public interface IActionResultFactory
    {
        IActionResult Build<T>(UseCaseResponse<T> response);
    }
}
