using EriccoreTech.EnterprisePlatform.ControlPlane.Model;

namespace EriccoreTech.EnterprisePlatform.ControlPlane.Service.Contracts {
    public interface IWorkflowManagementService {

        PublishWorkflowResponse PublishWorkflow(PublishWorkflowRequest request);

    }
}
