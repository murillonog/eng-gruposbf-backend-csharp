using eng_gruposbf_backend_csharp.Borders.Abstractions.UseCases;
using System;
using System.Net;
using System.Runtime.Serialization;

namespace eng_gruposbf_backend_csharp.Borders.Exceptions
{
    public class BusinessException : Exception, ISerializable
    {
        public ErrorMessage Error { get; }

        public BusinessException(int statusCode, string errorMessage)
            : base(errorMessage)
        {
            Error = new ErrorMessage(statusCode.ToString(), errorMessage);
        }

        public BusinessException(int statusCode)
            : base(string.Empty)
        {
            Error = new ErrorMessage(statusCode.ToString(), $"Error {statusCode}");
        }

        public BusinessException(HttpStatusCode statusCode, string errorMessage)
            : this(Convert.ToInt32(statusCode), errorMessage) { }

        public BusinessException(HttpStatusCode statusCode) : this(Convert.ToInt32(statusCode)) { }
    }
}
