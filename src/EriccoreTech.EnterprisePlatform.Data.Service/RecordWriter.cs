using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using EriccoreTech.EnterprisePlatform.Data.Model;

namespace EriccoreTech.EnterprisePlatform.Data.Service {
    // Drains the pending queue into SQL. Retries are safe because the insert is idempotent on RecordId.
    internal sealed class RecordWriter : BackgroundService {

        private const int MaxAttempts = 5;

        private readonly PendingRecordStore _pendingRecordStore;
        private readonly Contracts.IRecordRepository _recordRepository;
        private readonly ILogger<RecordWriter> _logger;

        public RecordWriter(PendingRecordStore pendingRecordStore, Contracts.IRecordRepository recordRepository, ILogger<RecordWriter> logger) {
            _pendingRecordStore = pendingRecordStore;
            _recordRepository = recordRepository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            try {
                await foreach (var record in _pendingRecordStore.ReadAllAsync(stoppingToken)) {
                    await PersistAsync(record, stoppingToken);
                }
            } catch (OperationCanceledException) {
                // shutting down: fall through and flush what is still queued
            }

            while (_pendingRecordStore.TryDequeue(out var remaining)) {
                await PersistAsync(remaining!, stoppingToken);
            }
        }

        private async Task PersistAsync(StoredRecord record, CancellationToken stoppingToken) {
            for (var attempt = 1; attempt <= MaxAttempts; attempt++) {
                try {
                    await _recordRepository.InsertAsync(record, CancellationToken.None);
                    _pendingRecordStore.Complete(record.RecordId);
                    return;
                } catch (Exception exception) {
                    if (attempt == MaxAttempts) {
                        // record stays readable from memory but is not persisted
                        _logger.LogError(exception, "Giving up persisting record {RecordId} after {Attempts} attempts", record.RecordId, attempt);
                        return;
                    }

                    _logger.LogWarning(exception, "Persisting record {RecordId} failed (attempt {Attempt})", record.RecordId, attempt);

                    if (stoppingToken.IsCancellationRequested) {
                        return;
                    }

                    try {
                        await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, attempt - 1)), stoppingToken);
                    } catch (OperationCanceledException) {
                        return;
                    }
                }
            }
        }

    }
}
