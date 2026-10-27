using EriccoreTech.EnterprisePlatform.ControlPlane.Model;

namespace EriccoreTech.EnterprisePlatform.ControlPlane.Service {
    public class WorkflowManagementService : Contracts.IWorkflowManagementService {

        public PublishWorkflowResponse PublishWorkflow(PublishWorkflowRequest request) {
            if (request is null) {
                throw new ArgumentNullException(nameof(request));
            }

            // implement behavior here
            throw new NotImplementedException();
        }

    }
}
