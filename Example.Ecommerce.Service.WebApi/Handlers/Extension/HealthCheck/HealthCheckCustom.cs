using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.NetworkInformation;
using System.Text;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.HealthCheck
{
    public class HealthCheckCustom : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            HealthCheckResult healthCheckResult = HealthCheckResult.Healthy("Healthy ping"); ;

            PingOptions options = new() { DontFragment = true };
            const string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            const string ipOrDNS = "8.8.8.8";
            const int timeout = 120;

            byte[] buffer = Encoding.ASCII.GetBytes(data);

            Ping pingSender = new();
            PingReply reply = pingSender.Send(ipOrDNS, timeout, buffer, options);

            if (reply.Status != IPStatus.Success)
            {
                healthCheckResult = HealthCheckResult.Unhealthy("Unhealthy Ping");
            }

            return Task.FromResult(healthCheckResult);
        }
    }
}
