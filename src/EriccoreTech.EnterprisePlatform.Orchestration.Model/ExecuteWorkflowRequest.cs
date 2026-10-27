namespace EriccoreTech.EnterprisePlatform.Orchestration.Model {
    public class ExecuteWorkflowRequest {

        public string WorkflowId { get; set; } = string.Empty;

        public int Version { get; set; }

    }
}
