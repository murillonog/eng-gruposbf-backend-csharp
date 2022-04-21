using System;
using System.Net;

namespace eng_gruposbf_backend_csharp.Borders.Abstractions.UseCases
{
    public class ErrorMessage
    {
        public string Code { get; }

        public string Message { get; }

        private ErrorMessage()
        {
        }

        public ErrorMessage(string code, string message) : this()
        {
            Code = code;
            Message = message;
        }

        public ErrorMessage(HttpStatusCode code, string message) : this(Convert.ToInt32(code).ToString(), message)
        {
        }

        public static ErrorMessage[] NullResponse(string serviceName)
        {
            return new[] { new ErrorMessage("000", "serviceName Error") };
        }

        public static ErrorMessage[] Unknown()
        {
            return new[] { new ErrorMessage("001", "Unknown error") };
        }
    }
}
