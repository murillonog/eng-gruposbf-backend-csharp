namespace eng_gruposbf_backend_csharp.Borders.Dtos.HealthCheck
{
    public class HealthCheckActivity
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public HealthCheckActivity() { }

        public HealthCheckActivity(string name, string message) : this()
        {
            Name = name;
            Message = message;
        }
    }
}
