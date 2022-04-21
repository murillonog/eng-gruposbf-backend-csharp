using System.Collections.Generic;
using System.Linq;

namespace eng_gruposbf_backend_csharp.Borders.Dtos.HealthCheck
{
    public class HealthCheckResponse
    {
        public List<HealthCheckActivity> Activities { get; }

        public HealthCheckResponse(IEnumerable<HealthCheckActivity> activities)
        {
            Activities = activities.ToList();
        }

        public HealthCheckResponse() : this(new List<HealthCheckActivity>()) { }
    }
}
