using Microsoft.AspNetCore.Mvc;
using EriccoreTech.EnterprisePlatform.Application.Model;
using EriccoreTech.EnterprisePlatform.Application.Service.Contracts;

namespace EriccoreTech.EnterprisePlatform.Application.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService) {
            _customerService = customerService;
        }

        [HttpPost]
        public SaveCustomerResponse SaveCustomer(SaveCustomerRequest request) {
            return _customerService.SaveCustomer(request);
        }

    }
}
