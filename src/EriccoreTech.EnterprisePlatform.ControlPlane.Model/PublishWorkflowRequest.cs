namespace EriccoreTech.EnterprisePlatform.ControlPlane.Model {
    public class PublishWorkflowRequest {

        public string WorkflowId { get; set; } = string.Empty;

        public int Version { get; set; }

    }
}
