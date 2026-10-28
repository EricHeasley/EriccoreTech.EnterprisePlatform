using EriccoreTech.EnterprisePlatform.Data.Model;

namespace EriccoreTech.EnterprisePlatform.Data.Service.Contracts {
    public interface IRecordRepository {

        // must be idempotent: inserting a RecordId that already exists is a success
        Task InsertAsync(StoredRecord record, CancellationToken cancellationToken);

        Task<StoredRecord?> GetAsync(Guid recordId, CancellationToken cancellationToken);

    }
}
