using EriccoreTech.EnterprisePlatform.Orchestration.Model;

namespace EriccoreTech.EnterprisePlatform.Orchestration.Service {
    public class WorkflowExecutionService : Contracts.IWorkflowExecutionService {

        public ExecuteWorkflowResponse ExecuteWorkflow(ExecuteWorkflowRequest request) {
            if (request is null) {
                throw new ArgumentNullException(nameof(request));
            }

            // implement behavior here
            throw new NotImplementedException();
        }

    }
}
