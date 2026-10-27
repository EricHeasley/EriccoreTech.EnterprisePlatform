using EriccoreTech.EnterprisePlatform.Application.Model;

namespace EriccoreTech.EnterprisePlatform.Application.Service.Contracts {
    public interface ICustomerService {

        SaveCustomerResponse SaveCustomer(SaveCustomerRequest request);

    }
}
