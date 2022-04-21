using eng_gruposbf_backend_csharp.Shared.Settings;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;

namespace eng_gruposbf_backend_csharp.Mocks
{
    public static class Options
    {
        public static IOptions<ApiGateway> ReportsApiGateway()
        {
            var mock = new Mock<IOptions<ApiGateway>>();

            mock.SetupGet(m => m.Value)
                .Returns(new ApiGateway
                {
                    Resources = new List<Resource>()
                    {
                        new Resource
                        {
                            Name = "Test Service",
                            BaseUrl = "http://servico.test",
                            Parameters = new List<Parameter>()
                            {
                                new Parameter
                                {
                                    Key = "Chave",
                                    Value = "Valor"
                                }
                            }
                        }
                    }
                });

            return mock.Object;
        }
    }
}
