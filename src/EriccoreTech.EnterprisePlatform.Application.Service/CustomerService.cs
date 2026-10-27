using EriccoreTech.EnterprisePlatform.Application.Model;

namespace EriccoreTech.EnterprisePlatform.Application.Service {
    public class CustomerService : Contracts.ICustomerService {

        public SaveCustomerResponse SaveCustomer(SaveCustomerRequest request) {
            if (request is null) {
                throw new ArgumentNullException(nameof(request));
            }

            // implement behavior here
            throw new NotImplementedException();
        }

    }
}
