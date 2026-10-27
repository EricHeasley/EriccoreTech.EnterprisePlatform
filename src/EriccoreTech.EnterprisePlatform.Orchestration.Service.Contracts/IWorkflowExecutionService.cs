using EriccoreTech.EnterprisePlatform.Orchestration.Model;

namespace EriccoreTech.EnterprisePlatform.Orchestration.Service.Contracts {
    public interface IWorkflowExecutionService {

        ExecuteWorkflowResponse ExecuteWorkflow(ExecuteWorkflowRequest request);

    }
}
