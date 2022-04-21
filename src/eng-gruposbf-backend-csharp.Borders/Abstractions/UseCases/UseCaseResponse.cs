using eng_gruposbf_backend_csharp.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace eng_gruposbf_backend_csharp.Borders.Abstractions.UseCases
{
    public class UseCaseResponse<TResponse>
    {
        public UseCaseResponseStatus Status { get; private set; }

        public IEnumerable<ErrorMessage> Errors { get; private set; }

        public TResponse Content { get; private set; }

        public bool HasErrors()
        {
            return Errors != null;
        }

        public UseCaseResponse<TResponse> Processing()
        {
            return SetStatus(UseCaseResponseStatus.Processing);
        }

        public UseCaseResponse<TResponse> NoContent()
        {
            return SetStatus(UseCaseResponseStatus.NoContent);
        }

        public UseCaseResponse<TResponse> Ok(TResponse content)
        {
            Content = content;
            return SetStatus(UseCaseResponseStatus.Ok);
        }

        public UseCaseResponse<TResponse> BadRequest()
        {
            return SetStatus(UseCaseResponseStatus.BadRequest);
        }

        public UseCaseResponse<TResponse> Unauthorized()
        {
            return SetStatus(UseCaseResponseStatus.Unauthorized);
        }

        public UseCaseResponse<TResponse> Forbidden()
        {
            return SetStatus(UseCaseResponseStatus.Forbidden);
        }

        public UseCaseResponse<TResponse> NotFound()
        {
            return SetStatus(UseCaseResponseStatus.NotFound);
        }

        public UseCaseResponse<TResponse> InternalServerError(params ErrorMessage[] errors)
        {
            return SetStatus(UseCaseResponseStatus.InternalServerError, errors);
        }

        public UseCaseResponse<TResponse> InternalServerError(Exception ex)
        {
            var collection = ex.EnumerateExceptions()
                .Select(e => new ErrorMessage(HttpStatusCode.InternalServerError, e.Message))
                .ToArray();

            return InternalServerError(collection);
        }

        private UseCaseResponse<TResponse> SetStatus(UseCaseResponseStatus status,
            IEnumerable<ErrorMessage> errors = null)
        {
            Status = status;
            Errors = errors;

            return this;
        }
    }
}
