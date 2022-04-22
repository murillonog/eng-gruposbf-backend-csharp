using eng_gruposbf_backend_csharp.Api.Factories;
using eng_gruposbf_backend_csharp.Borders.Repositories.BacenConverter;
using eng_gruposbf_backend_csharp.Borders.Repositories.CurrencyExchange;
using eng_gruposbf_backend_csharp.Borders.Repositories.HealthCheck;
using eng_gruposbf_backend_csharp.Borders.UseCases.HealthCheck;
using eng_gruposbf_backend_csharp.Borders.UseCases.ListCoins;
using eng_gruposbf_backend_csharp.Borders.UseCases.PriceConverter;
using eng_gruposbf_backend_csharp.Repositories.Repositories;
using eng_gruposbf_backend_csharp.Shared;
using eng_gruposbf_backend_csharp.Shared.Extensions;
using eng_gruposbf_backend_csharp.Shared.Settings;
using eng_gruposbf_backend_csharp.UseCases.HealthCheck;
using eng_gruposbf_backend_csharp.UseCases.ListCoins;
using eng_gruposbf_backend_csharp.UseCases.PriceConverter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;

namespace eng_gruposbf_backend_csharp.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    internal static class StartupExtensions
    {
        internal static void UseApiServices(this IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseSwagger(options => { options.RouteTemplate = Constants.SwaggerRouteTemplate; });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(Constants.SwaggerUiEndpoingUrl, Constants.SwaggerApiVersion);
                options.RoutePrefix = Constants.SwaggerApiEndpoint;
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        internal static void AddServices(this IServiceCollection services)
        {
            services.AddApi();
            services.AddUseCases();
            services.AddRepositories();
            services.AddHttpClientFactories();
            services.AddSwagger();
            services.AddConfigurationBinding();
            services.AddMvc();
            services.AddControllers();
        }

        private static void AddApi(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IActionResultFactory, ActionResultFactory>();

        }

        private static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IHealthCheckUseCase, HealthCheckUseCase>();
            services.AddScoped<IListCoinsUseCase, ListCoinsUseCase>();
            services.AddScoped<IPriceConverterUseCase, PriceConverterUseCase>();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IHealthCheckRepository, HealthCheckRepository>();
            services.AddScoped<IBacenConverterRepository, BacenConverterRepository>();
            services.AddScoped<ICurrencyExchangeRepository, CurrencyExchangeRepository>();            
        }

        private static void AddHttpClientFactories(this IServiceCollection services)
        {
            services
                .AddHttpClient(Constants.BCBService, (provider, client) =>
                {
                    var options = provider.GetRequiredService<IOptions<ApiGateway>>();
                    var resource = options.Value.GetResource(Constants.BCBService);

                    client.BaseAddress = new Uri(resource.BaseUrl);
                });

            services
                .AddHttpClient(Constants.CurrencyService, (provider, client) =>
                {
                    var options = provider.GetRequiredService<IOptions<ApiGateway>>();
                    var resource = options.Value.GetResource(Constants.CurrencyService);

                    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", Constants.CurrencyServiceKey);

                    client.BaseAddress = new Uri(resource.BaseUrl);
                });
        }

        private static IServiceCollection AddConfigurationBinding(this IServiceCollection services)
        {
            services.AddOptions<ApiGateway>()
                .Configure<IConfiguration>((gateway, configuration) =>
                {
                    configuration
                        .GetSection(nameof(ApiGateway))
                        .Bind(gateway);
                });

            return services;
        }

        private static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(Constants.SwaggerApiVersion, new OpenApiInfo
                {
                    Title = Constants.SwaggerOpenApiInfoTitle,
                    Description = Constants.SwaggerOpenApiInfoDescription
                });                

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

        }
    }
}
