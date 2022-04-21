using System.Collections.Generic;

namespace eng_gruposbf_backend_csharp.Borders.Dtos.ListCoins
{
    public class ListCoinsResponse
    {
        public List<string> List { get; set; }

        public ListCoinsResponse(List<string> list)
        {
            List = list;
        }
    }
}
