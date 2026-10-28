using System.Collections.Concurrent;
using System.Threading.Channels;
using EriccoreTech.EnterprisePlatform.Data.Model;

namespace EriccoreTech.EnterprisePlatform.Data.Service {
    // Holds records accepted but not yet persisted: a queue for the writer, and a lookup so reads see them.
    internal sealed class PendingRecordStore {

        private readonly ConcurrentDictionary<Guid, StoredRecord> _records = new();
        private readonly Channel<StoredRecord> _queue;

        public PendingRecordStore(int capacity) {
            _queue = Channel.CreateBounded<StoredRecord>(new BoundedChannelOptions(capacity) {
                SingleReader = true,
                FullMode = BoundedChannelFullMode.Wait
            });
        }

        public async ValueTask EnqueueAsync(StoredRecord record, CancellationToken cancellationToken) {
            _records[record.RecordId] = record;

            try {
                await _queue.Writer.WriteAsync(record, cancellationToken);
            } catch {
                _records.TryRemove(record.RecordId, out _);
                throw;
            }
        }

        public bool TryGet(Guid recordId, out StoredRecord? record) {
            return _records.TryGetValue(recordId, out record);
        }

        public IAsyncEnumerable<StoredRecord> ReadAllAsync(CancellationToken cancellationToken) {
            return _queue.Reader.ReadAllAsync(cancellationToken);
        }

        public bool TryDequeue(out StoredRecord? record) {
            return _queue.Reader.TryRead(out record);
        }

        // call only after the record is committed to SQL
        public void Complete(Guid recordId) {
            _records.TryRemove(recordId, out _);
        }

    }
}
