namespace eng_gruposbf_backend_csharp.Borders.Abstractions.UseCases
{
    public enum UseCaseResponseStatus
    {
        Processing = 102,
        Ok = 200,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500,
    }
}
