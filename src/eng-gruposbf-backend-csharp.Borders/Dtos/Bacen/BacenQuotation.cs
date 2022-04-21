using eng_gruposbf_backend_csharp.Borders.Dtos.Currency;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace eng_gruposbf_backend_csharp.Borders.Dtos.Bacen
{
    public class BacenQuotation
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        public IEnumerable<Quotations> Value { get; set; }
    }
}
