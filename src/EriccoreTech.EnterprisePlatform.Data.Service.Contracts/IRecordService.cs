using EriccoreTech.EnterprisePlatform.Data.Model;

namespace EriccoreTech.EnterprisePlatform.Data.Service.Contracts {
    public interface IRecordService {

        Task<SaveRecordResponse> SaveRecordAsync(SaveRecordRequest request, CancellationToken cancellationToken = default);

        Task<GetRecordResponse> GetRecordAsync(GetRecordRequest request, CancellationToken cancellationToken = default);

    }
}
