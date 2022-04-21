using eng_gruposbf_backend_csharp.Shared.Settings;
using System.Linq;

namespace eng_gruposbf_backend_csharp.Shared.Extensions
{
    public static class ApiGatewayExtensions
    {
        public static Resource GetResource(this ApiGateway apiGateway, string name)
        {
            return apiGateway.Resources.FirstOrDefault(r => r.Name.Equals(name));
        }

        public static Parameter GetParameter(this Resource resource, string key)
        {
            return resource.Parameters.FirstOrDefault(p => p.Key.Equals(key));
        }
    }
}
