using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace eng_gruposbf_backend_csharp.Shared.Settings
{
    [ExcludeFromCodeCoverage]
    public class Resource
    {
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public List<Parameter> Parameters { get; set; }
    }
}
