using EriccoreTech.EnterprisePlatform.Data.Model;

namespace EriccoreTech.EnterprisePlatform.Data.Service {
    internal sealed class RecordService : Contracts.IRecordService {

        private readonly PendingRecordStore _pendingRecordStore;
        private readonly Contracts.IRecordRepository _recordRepository;

        public RecordService(PendingRecordStore pendingRecordStore, Contracts.IRecordRepository recordRepository) {
            _pendingRecordStore = pendingRecordStore;
            _recordRepository = recordRepository;
        }

        public async Task<SaveRecordResponse> SaveRecordAsync(SaveRecordRequest request, CancellationToken cancellationToken = default) {
            if (request is null) {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.RecordType)) {
                return new SaveRecordResponse {
                    Status = false,
                    Message = "RecordType is required"
                };
            }

            var record = new StoredRecord {
                RecordId = Guid.NewGuid(),
                RecordType = request.RecordType,
                Payload = request.Payload,
                CreatedDate = DateTime.UtcNow
            };

            await _pendingRecordStore.EnqueueAsync(record, cancellationToken);

            return new SaveRecordResponse {
                Status = true,
                Message = "Accepted",
                RecordId = record.RecordId
            };
        }

        public async Task<GetRecordResponse> GetRecordAsync(GetRecordRequest request, CancellationToken cancellationToken = default) {
            if (request is null) {
                throw new ArgumentNullException(nameof(request));
            }

            if (_pendingRecordStore.TryGet(request.RecordId, out var pending)) {
                return new GetRecordResponse {
                    Status = true,
                    Found = true,
                    Record = pending,
                    Source = "Memory"
                };
            }

            var persisted = await _recordRepository.GetAsync(request.RecordId, cancellationToken);

            return new GetRecordResponse {
                Status = true,
                Found = persisted is not null,
                Record = persisted,
                Source = persisted is null ? null : "Sql"
            };
        }

    }
}
