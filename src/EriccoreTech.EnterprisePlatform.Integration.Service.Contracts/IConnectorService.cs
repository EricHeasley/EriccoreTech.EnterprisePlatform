using EriccoreTech.EnterprisePlatform.Integration.Model;

namespace EriccoreTech.EnterprisePlatform.Integration.Service.Contracts {
    public interface IConnectorService {

        InvokeConnectorResponse InvokeConnector(InvokeConnectorRequest request);

    }
}
