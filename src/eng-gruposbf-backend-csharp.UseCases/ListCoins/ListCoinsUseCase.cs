using eng_gruposbf_backend_csharp.Borders.Abstractions.UseCases;
using eng_gruposbf_backend_csharp.Borders.Dtos.Enums;
using eng_gruposbf_backend_csharp.Borders.Dtos.ListCoins;
using eng_gruposbf_backend_csharp.Borders.UseCases.ListCoins;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eng_gruposbf_backend_csharp.UseCases.ListCoins
{
    public class ListCoinsUseCase : IListCoinsUseCase
    {
        public async Task<UseCaseResponse<ListCoinsResponse>> Execute()
        {
            var response = new UseCaseResponse<ListCoinsResponse>();

            try
            {
                var list = Enum.GetNames(typeof(Coins)).ToList();
                response.Ok(new ListCoinsResponse(list));
            }
            catch (Exception exception)
            {
                response.InternalServerError(exception);
            }

            return response;
        }
    }
}
