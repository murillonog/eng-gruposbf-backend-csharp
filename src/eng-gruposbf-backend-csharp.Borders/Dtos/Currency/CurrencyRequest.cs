namespace eng_gruposbf_backend_csharp.Borders.Dtos.Currency
{
    public class CurrencyRequest
    {
        public decimal Value { get; set; }

        public CurrencyRequest()
        {

        }

        public CurrencyRequest(decimal value)
        {
            Value = value;
        }
    }
}
