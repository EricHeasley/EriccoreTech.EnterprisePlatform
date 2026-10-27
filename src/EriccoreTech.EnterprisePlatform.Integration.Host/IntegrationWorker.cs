namespace EriccoreTech.EnterprisePlatform.Integration.Host {
    public class IntegrationWorker : BackgroundService {

        private readonly ILogger<IntegrationWorker> _logger;

        public IntegrationWorker(ILogger<IntegrationWorker> logger) {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            _logger.LogInformation("Integration worker started");

            // implement behavior here
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }

    }
}
