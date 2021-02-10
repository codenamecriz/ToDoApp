using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.HealthChecks
{
    public class ResponseTimeHealthCheck : IHealthCheck
    {
        private Random rnd = new Random();
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            int responseTime = rnd.Next(1, 300);

            if (responseTime < 100)
            {
                return Task.FromResult(HealthCheckResult.Healthy($"The Response Time Looks Good ({responseTime})ms"));
            }
            else if (responseTime < 200)
            {
                return Task.FromResult(HealthCheckResult.Degraded($"The Response Time is a bit slow ({responseTime})ms"));
            }
            else
            {
                return Task.FromResult(HealthCheckResult.Unhealthy($"The Response Time unacceptable ({responseTime})ms"));
            }


        }
    }
}
