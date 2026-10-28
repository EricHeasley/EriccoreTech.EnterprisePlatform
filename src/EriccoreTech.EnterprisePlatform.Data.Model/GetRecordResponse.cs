namespace EriccoreTech.EnterprisePlatform.Data.Model {
    public class GetRecordResponse {

        public bool Status { get; set; }

        public string? Message { get; set; }

        public bool Found { get; set; }

        public StoredRecord? Record { get; set; }

        // "Memory" while the insert is still queued, "Sql" once it is persisted
        public string? Source { get; set; }

    }
}
