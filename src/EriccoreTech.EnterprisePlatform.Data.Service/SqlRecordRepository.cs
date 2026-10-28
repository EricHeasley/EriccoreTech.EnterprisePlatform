using System.Data;
using Microsoft.Data.SqlClient;
using EriccoreTech.EnterprisePlatform.Data.Model;

namespace EriccoreTech.EnterprisePlatform.Data.Service {
    internal sealed class SqlRecordRepository : Contracts.IRecordRepository {

        private readonly string _connectionString;

        public SqlRecordRepository(string connectionString) {
            _connectionString = connectionString;
        }

        public async Task InsertAsync(StoredRecord record, CancellationToken cancellationToken) {
            await using var connection = new SqlConnection(_connectionString);
            await using var command = new SqlCommand("dbo.usp_INSERT_Record", connection) {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@RecordId", record.RecordId);
            command.Parameters.AddWithValue("@RecordType", record.RecordType);
            command.Parameters.AddWithValue("@Payload", record.Payload);
            command.Parameters.Add(new SqlParameter("@CreatedDate", SqlDbType.DateTime2) { Value = record.CreatedDate });

            await connection.OpenAsync(cancellationToken);
            await command.ExecuteNonQueryAsync(cancellationToken);
        }

        public async Task<StoredRecord?> GetAsync(Guid recordId, CancellationToken cancellationToken) {
            await using var connection = new SqlConnection(_connectionString);
            await using var command = new SqlCommand("dbo.usp_GET_Record", connection) {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("@RecordId", recordId);

            await connection.OpenAsync(cancellationToken);
            await using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (!await reader.ReadAsync(cancellationToken)) {
                return null;
            }

            return new StoredRecord {
                RecordId = reader.GetGuid(reader.GetOrdinal("RecordId")),
                RecordType = reader.GetString(reader.GetOrdinal("RecordType")),
                Payload = reader.GetString(reader.GetOrdinal("Payload")),
                CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"))
            };
        }

    }
}
