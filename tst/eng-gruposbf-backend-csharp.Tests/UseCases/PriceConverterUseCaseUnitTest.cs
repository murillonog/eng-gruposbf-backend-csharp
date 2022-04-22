using eng_gruposbf_backend_csharp.Borders.Dtos.Currency;
using eng_gruposbf_backend_csharp.Borders.Repositories.BacenConverter;
using eng_gruposbf_backend_csharp.Borders.Repositories.CurrencyExchange;
using eng_gruposbf_backend_csharp.Tests.Builders;
using eng_gruposbf_backend_csharp.UseCases.PriceConverter;
using FluentAssertions;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace eng_gruposbf_backend_csharp.Tests.UseCases
{
    public class PriceConverterUseCaseUnitTest
    {
        private readonly Mock<IBacenConverterRepository> _bacenConverterRepository;
        private readonly Mock<ICurrencyExchangeRepository> _currencyExchangeRepository;

        public PriceConverterUseCaseUnitTest()
        {
            _bacenConverterRepository = new Mock<IBacenConverterRepository>();
            _currencyExchangeRepository = new Mock<ICurrencyExchangeRepository>();
        }

        [Fact]
        public async Task PriceConverter_UseCase_BacenRepository_ok()
        {
            var request = new CurrencyRequest(10);

            _bacenConverterRepository.Setup(p => p.Get(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(() => new BacenQuotationBuilder().Builder());

            _currencyExchangeRepository.Setup(p => p.Get(It.IsAny<string>()));

            var useCase = new PriceConverterUseCase(
                _bacenConverterRepository.Object,
                _currencyExchangeRepository.Object);

            var result = await useCase.Execute(request);

            result.Content.Should().NotBeNull();
            result.Content.Currencies.Should().NotBeNull().And.NotBeEmpty();
            result.Content.Currencies.FirstOrDefault().Should().NotBeNull();
        }

        [Fact]
        public async Task PriceConverter_UseCase_CurrencyRepository_ok()
        {
            var request = new CurrencyRequest(10);

            _bacenConverterRepository.Setup(p => p.Get(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(() => new BacenQuotationBuilder().Builder());

            _currencyExchangeRepository.Setup(p => p.Get(It.IsAny<string>()))
                .ReturnsAsync(1.5m);

            var useCase = new PriceConverterUseCase(
                _bacenConverterRepository.Object,
                _currencyExchangeRepository.Object);

            var result = await useCase.Execute(request);

            result.Content.Should().NotBeNull();
            result.Content.Currencies.Should().NotBeNull().And.NotBeEmpty();
            result.Content.Currencies.FirstOrDefault().Should().NotBeNull();
        }

        [Fact]
        public async Task PriceConverter_UseCase_Error_BacenRepository()
        {
            var request = new CurrencyRequest(10);

            _bacenConverterRepository.Setup(p => p.Get(It.IsAny<string>(), It.IsAny<string>()))
                .Throws(() => new Exception());

            _currencyExchangeRepository.Setup(p => p.Get(It.IsAny<string>()));

            var useCase = new PriceConverterUseCase(
                _bacenConverterRepository.Object,
                _currencyExchangeRepository.Object);

            var result = await useCase.Execute(request);

            result.Errors.Should().NotBeNull().And.NotBeEmpty();
            result.Errors.FirstOrDefault().Should().NotBeNull();
        }

        [Fact]
        public async Task PriceConverter_UseCase_Error_CurrencyRepository()
        {
            var request = new CurrencyRequest(10);

            _bacenConverterRepository.Setup(p => p.Get(It.IsAny<string>(), It.IsAny<string>())); ;

            _currencyExchangeRepository.Setup(p => p.Get(It.IsAny<string>()))
                .Throws(() => new Exception());

            var useCase = new PriceConverterUseCase(
                _bacenConverterRepository.Object,
                _currencyExchangeRepository.Object);

            var result = await useCase.Execute(request);

            result.Errors.Should().NotBeNull().And.NotBeEmpty();
            result.Errors.FirstOrDefault().Should().NotBeNull();
        }
    }
}
