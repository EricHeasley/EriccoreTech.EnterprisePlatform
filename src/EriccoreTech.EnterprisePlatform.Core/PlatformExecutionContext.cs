namespace EriccoreTech.EnterprisePlatform.Core {
    public class PlatformExecutionContext {

        public Guid ExecutionId { get; set; }

        public string CorrelationId { get; set; } = string.Empty;

        public string? TenantId { get; set; }

        public string? UserIdentity { get; set; }

    }
}
