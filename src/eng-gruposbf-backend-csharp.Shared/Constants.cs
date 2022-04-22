namespace eng_gruposbf_backend_csharp.Shared
{
    public static class Constants
    {
        public const string SwaggerApiVersion = "v1";
        public const string SwaggerOpenApiInfoTitle = "Price Converter API";
        public const string SwaggerOpenApiInfoDescription = "API for converting prices in different currencies";
        public const string SwaggerUiEndpoingUrl = "/" + SwaggerApiEndpoint + "/v1/swagger.json";
        public const string SwaggerRouteTemplate = SwaggerApiEndpoint + "/{documentName}/swagger.json";
        public const string SwaggerApiEndpoint = "api-docs";

        public const string CurrencyService = "Currency";
        public const string CurrencyServiceKey = "e840759f8cmsh804171f4a41a09fp147e6fjsn48d6f0205093";
        public const string BCBService = "BCB";
    }
}
