using eng_gruposbf_backend_csharp.Borders.Repositories.HealthCheck;
using eng_gruposbf_backend_csharp.UseCases.HealthCheck;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace eng_gruposbf_backend_csharp.Tests.UseCases
{
    public class HealthCheckUseCaseUnitTest
    {
        private readonly Mock<IHealthCheckRepository> _healthCheckRepository;
        public HealthCheckUseCaseUnitTest()
        {
            _healthCheckRepository = new Mock<IHealthCheckRepository>();
        }

        [Fact]
        public async Task HealthCheck_UseCase_Ok()
        {
            _healthCheckRepository.Setup(h => h.Ping(It.IsAny<string>()))
                .ReturnsAsync(() => IPStatus.Success.ToString());

            var useCase = new HealthCheckUseCase(
                _healthCheckRepository.Object,
                Mocks.Options.ReportsApiGateway());

            var result = await useCase.Execute();

            result.Content.Should().NotBeNull();
            result.Content.Activities.Should().NotBeNull().And.NotBeEmpty();
            result.Content.Activities.FirstOrDefault().Should().NotBeNull();
            result.Content.Activities.FirstOrDefault()?.Message.Should().BeEquivalentTo(IPStatus.Success.ToString());
        }

        [Fact]
        public async Task HealthCheck_UseCase_ReturnsExceptions()
        {
            _healthCheckRepository.Setup(h => h.Ping(It.IsAny<string>()))
                .Throws(() => new Exception());

            var useCase = new HealthCheckUseCase(
                _healthCheckRepository.Object,
                Mocks.Options.ReportsApiGateway());

            var result = await useCase.Execute();

            result.Errors.Should().NotBeNull().And.NotBeEmpty();
            result.Errors.FirstOrDefault().Should().NotBeNull();
        }
    }
}
