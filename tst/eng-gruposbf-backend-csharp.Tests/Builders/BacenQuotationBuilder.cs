using eng_gruposbf_backend_csharp.Borders.Dtos.Bacen;
using eng_gruposbf_backend_csharp.Borders.Dtos.Currency;
using System;
using System.Collections.Generic;

namespace eng_gruposbf_backend_csharp.Tests.Builders
{
    public class BacenQuotationBuilder
    {
        private readonly BacenQuotation _instance;
        private readonly BacenQuotation _instanceEmpty;
        public BacenQuotationBuilder()
        {
            _instance = new BacenQuotation()
            {
                OdataContext = "teste",
                Value= new List<Quotations>()
                {
                    new Quotations()
                    {
                        ParidadeCompra = 1,
                        ParidadeVenda = 1,
                        CotacaoCompra = 1,
                        CotacaoVenda = 1,
                        DataHoraCotacao = DateTime.Now,
                        TipoBoletim = "teste"
                    }
                }
            };

            _instanceEmpty = new BacenQuotation()
            {
                OdataContext = "teste",
                Value = new List<Quotations>()
            };
        }

        public BacenQuotation Builder() => _instance;
    }
}
