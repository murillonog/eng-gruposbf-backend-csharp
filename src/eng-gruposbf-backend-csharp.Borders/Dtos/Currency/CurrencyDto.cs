namespace eng_gruposbf_backend_csharp.Borders.Dtos.Currency
{
    public class CurrencyDto
    {
        public CurrencyDto(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
