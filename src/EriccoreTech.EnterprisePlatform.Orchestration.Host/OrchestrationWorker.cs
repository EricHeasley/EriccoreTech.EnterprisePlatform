namespace EriccoreTech.EnterprisePlatform.Orchestration.Host {
    public class OrchestrationWorker : BackgroundService {

        private readonly ILogger<OrchestrationWorker> _logger;

        public OrchestrationWorker(ILogger<OrchestrationWorker> logger) {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            _logger.LogInformation("Orchestration worker started");

            // implement behavior here
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }

    }
}
