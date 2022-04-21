namespace eng_gruposbf_backend_csharp.Shared
{
    public static class Constants
    {
        public const string SwaggerApiVersion = "v1";
        public const string SwaggerOpenApiInfoTitle = "Gateway";
        public const string SwaggerOpenApiInfoDescription = "Api Gateway para integração de apis";
        public const string SwaggerUiEndpoingUrl = "/" + SwaggerApiEndpoint + "/v1/swagger.json";
        public const string SwaggerRouteTemplate = SwaggerApiEndpoint + "/{documentName}/swagger.json";
        public const string SwaggerApiEndpoint = "api-docs";

        public const string CurrencyService = "Currency";
        public const string CurrencyServiceKey = "e840759f8cmsh804171f4a41a09fp147e6fjsn48d6f0205093";
        public const string BCBService = "BCB";
    }
}
