namespace EriccoreTech.EnterprisePlatform.Integration.Model {
    public class InvokeConnectorRequest {

        public string ConnectorId { get; set; } = string.Empty;

        public string Operation { get; set; } = string.Empty;

    }
}
