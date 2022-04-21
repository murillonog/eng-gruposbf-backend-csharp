using System;

namespace eng_gruposbf_backend_csharp.Borders.Dtos.Currency
{
    public class Quotations
    {
        public decimal ParidadeCompra { get; set; }
        public decimal ParidadeVenda { get; set; }
        public decimal CotacaoCompra { get; set; }
        public decimal CotacaoVenda { get; set; }
        public DateTime DataHoraCotacao { get; set; }
        public string TipoBoletim { get; set; }
    }
}
