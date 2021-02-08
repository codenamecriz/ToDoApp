using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rabbit.Consumer
{
    public class HostServices : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IRabbitMQService _rabbitService;
        private readonly IConsumerMassTransitConfig _consumerMassTransitConfig;

        public HostServices(
            ILogger<HostServices> logger,
            IHostApplicationLifetime appLifetime,
            IRabbitMQService rabbitService, 
            IConsumerMassTransitConfig consumerMassTransitConfig)
        {
            _logger = logger;

            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStopped);

            _rabbitService = rabbitService;
            _consumerMassTransitConfig = consumerMassTransitConfig;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("1. StartAsync has been called.");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("4. StopAsync has been called.");

            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            
            _logger.LogInformation("2. OnStarted has been called.");
            //_consumerMassTransitConfig.RabbitToMassTransit();
            _rabbitService.RabbitConsumerRun();
        }

        private void OnStopping()
        {
            _logger.LogInformation("3. OnStopping has been called.");
        }

        private void OnStopped()
        {
            _logger.LogInformation("5. OnStopped has been called.");
        }
    }
}
