using EriccoreTech.EnterprisePlatform.Integration.Model;

namespace EriccoreTech.EnterprisePlatform.Integration.Service {
    public class ConnectorService : Contracts.IConnectorService {

        public InvokeConnectorResponse InvokeConnector(InvokeConnectorRequest request) {
            if (request is null) {
                throw new ArgumentNullException(nameof(request));
            }

            // implement behavior here
            throw new NotImplementedException();
        }

    }
}
