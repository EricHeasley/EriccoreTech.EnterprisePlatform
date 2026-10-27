using Microsoft.AspNetCore.Mvc;
using EriccoreTech.EnterprisePlatform.ControlPlane.Model;
using EriccoreTech.EnterprisePlatform.ControlPlane.Service.Contracts;

namespace EriccoreTech.EnterprisePlatform.ControlPlane.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class WorkflowManagementController : ControllerBase {

        private readonly IWorkflowManagementService _workflowManagementService;

        public WorkflowManagementController(IWorkflowManagementService workflowManagementService) {
            _workflowManagementService = workflowManagementService;
        }

        [HttpPost]
        public PublishWorkflowResponse PublishWorkflow(PublishWorkflowRequest request) {
            return _workflowManagementService.PublishWorkflow(request);
        }

    }
}
