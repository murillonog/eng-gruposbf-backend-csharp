using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace eng_gruposbf_backend_csharp.Shared.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ExceptionExtensions
    {
        public static IEnumerable<Exception> EnumerateExceptions(this Exception ex)
        {
            while (ex != null)
            {
                yield return ex;
                ex = ex.InnerException;
            }
        }
    }
}
